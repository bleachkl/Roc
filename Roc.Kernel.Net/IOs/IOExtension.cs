using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Documents;

namespace Roc.Kernel.Extensions.ForIO
{
    /// <summary>
    /// 文件系统IO拓展
    /// </summary>
    public static class IOExtension
    {
        /// <summary>
        /// 异步锁
        /// </summary>
        internal static readonly object ms_AsyncLock = new object();
        /// <summary>
        /// 默认文件编码名称
        /// </summary>
        public static string EncodingNameFileDefault { get; } = strings.EncodingUTF8;

        /// <summary>
        /// 默认文件编码
        /// </summary>
        public static Encoding EncodingFileDefault { get; } = Encoding.GetEncoding(EncodingNameFileDefault);
        /// <summary>
        /// 是否写入日志
        /// </summary>
        public static bool AlwaysToLogs { get; set; } = false;
        /// <summary>
        /// 超出容量时是否写入日志
        /// </summary>
        public static bool OutCapacityToLogs { get; set; } = false;

        /// <summary>
        /// IO操作失败异常存储容量
        /// 用于防止在x86系统中出现outofmemory
        /// </summary>
        public static int IOExceptionsCapacity { get; } = 5000;
        /// <summary>
        /// IO操作失败异常
        /// </summary>
        internal static ConcurrentBag<Exception> m_IOExceptions = new ConcurrentBag<Exception>();
        /// <summary>
        /// IO操作失败异常
        /// </summary>
        public static ConcurrentBag<Exception> IOExceptions
        {
            get { return m_IOExceptions; }
            internal set { m_IOExceptions = value; }
        }
        /// <summary>
        /// 最后一个触发的IO异常
        /// </summary>
        public static Exception LastIOException { get; internal set; }
        /// <summary>
        /// 添加IO异常
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Exception AddIOException(Exception exception)
        {
            lock (ms_AsyncLock)
            {
                Exception outIOException = default;
                while (m_IOExceptions?.Count == IOExceptionsCapacity)
                    if (m_IOExceptions.TryTake(out outIOException))
                    {
                        break;
                    }
                m_IOExceptions.Add(exception);
                LastIOException = exception;
                return exception;
            }
        }

        /// <summary>
        /// 同时操作的文本路径容量
        /// 用于防止在x86系统中出现outofmemory
        /// 或防止内存较低的机器出现内存溢出
        /// </summary>
        public static int UsingFilesCapacity { get; } = 5000;
        /// <summary>
        /// IO正在操作文本路径
        /// </summary>
        internal static List<string> m_UsingFilesPathes = new List<string>(UsingFilesCapacity);
        /// <summary>
        /// IO正在操作文本路径
        /// </summary>
        public static List<string> UsingFilesPathes
        {
            get { return m_UsingFilesPathes; }
            internal set { m_UsingFilesPathes = value; }
        }
        /// <summary>
        /// 尝试锁定文件
        /// 返回不为空的Exception时表示文件正在使用中
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static Exception TryLockUsingFilePath(string filePath)
        {
            lock (ms_AsyncLock)
            {
                if (UsingFilesPathes.Contains(filePath))
                {
                    return AddIOException(new Exception($"文件正在使用中({filePath})!"));
                }
                else
                {
                    if (UsingFilesPathes.Count < UsingFilesPathes.Capacity)
                    {
                        UsingFilesPathes.Add(filePath);
                        return default;
                    }
                    else
                        return AddIOException(new Exception($"同时操作的文件达到最大容量,请等待资源释放({filePath})!"));
                }
            }
        }
        /// <summary>
        /// 解锁文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static void UnlockUsingFilePath(string filePath)
        {
            lock (ms_AsyncLock)
            {
                UsingFilesPathes.Remove(filePath);
            }
        }
        /// <summary>
        /// 判断是否为文件夹路径的辅助文件名
        /// </summary>
        static string ms_DemoFileName { get; } = "IOExtension.txt";
        /// <summary>
        /// 是否是文件夹路径
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static bool IsDirectory(this string dir)
        {
            try
            {
                var path = Path.Combine(dir, ms_DemoFileName);
                if (Path.GetDirectoryName(path)?.Length > 0
                       && Path.GetFileName(path)?.Length > 0
                       && Path.GetPathRoot(path)?.Length > 0)
                {
                    return default != new FileInfo(path).Directory;
                }
                return false;
            }
            catch (Exception exception)
            {
                AddIOException(exception);
                return false;
            }
        }
        /// <summary>
        /// 获取文件夹路径
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetDirectory(this string filePath)
        {
            try
            {
                return new FileInfo(filePath)?.Directory?.FullName;
            }
            catch (Exception exception)
            {
                AddIOException(exception);
                return string.Empty;
            }
        }
        /// <summary>
        /// 获取文件名包含后缀名
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetFileFullName(this string filePath)
        {
            try
            {
                var fileInfo = new FileInfo(filePath);
                return $"{fileInfo.Name}";
            }
            catch (Exception exception)
            {
                AddIOException(exception);
                return string.Empty;
            }
        }
        /// <summary>
        /// 获取文件名不包含后缀名
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetFileName(this string filePath)
        {
            try
            {
                var fileInfo = new FileInfo(filePath);
                return $"{fileInfo.Name.Substring(0, fileInfo.Name.Length - fileInfo.Extension.Length)}";
            }
            catch (Exception exception)
            {
                AddIOException(exception);
                return string.Empty;
            }
        }
        /// <summary>
        /// 获取文件后缀名
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetFileExtensionName(this string filePath)
        {
            try
            {
                var fileInfo = new FileInfo(filePath);
                return $"{(fileInfo.Extension.Length > 0 ? fileInfo.Extension.Substring(1, fileInfo.Extension.Length - 1) : fileInfo.Extension)}";
            }
            catch (Exception exception)
            {
                AddIOException(exception);
                return string.Empty;
            }
        }

        /// <summary>
        /// 获取文件名包含后缀名
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string ReplaceFileFullName(this string filePath, string newFileFullName)
        {
            try
            {
                var fileInfo = new FileInfo(filePath);
                filePath = Path.Combine($"{fileInfo.Directory.FullName}", newFileFullName);
                if (filePath.IsFilePath())
                {
                    return filePath;
                }
                else
                    return fileInfo.FullName;
            }
            catch (Exception exception)
            {
                AddIOException(exception);
                return string.Empty;
            }
        }
        /// <summary>
        /// 替换文件名不包含后缀名
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string ReplaceFileName(this string filePath, string newFileName)
        {
            try
            {
                var fileInfo = new FileInfo(filePath);
                filePath = Path.Combine($"{fileInfo.Directory.FullName}", $"{newFileName}{fileInfo.Extension}");
                if (filePath.IsFilePath())
                {
                    return filePath;
                }
                else
                    return fileInfo.FullName;
            }
            catch (Exception exception)
            {
                AddIOException(exception);
                return string.Empty;
            }
        }
        /// <summary>
        ///  替换文件后缀名
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string ReplaceFileExtensionName(this string filePath, string newExtension)
        {
            try
            {
                newExtension = chars.ENPeriod == newExtension?.First() ?
                    newExtension : $"{strings.ENPeriod}{newExtension}";
                var fileInfo = new FileInfo(filePath);
                var fileName = fileInfo.Name;
                if (fileInfo.Extension?.Length > 0)
                    fileName = $"{fileInfo.Name.Substring(0, fileInfo.Name.Length - fileInfo.Extension.Length)}";
                filePath = Path.Combine($"{fileInfo.Directory.FullName}", $"{fileName}{newExtension}");
                if (filePath.IsFilePath())
                {
                    return filePath;
                }
                else
                    return fileInfo.FullName;
            }
            catch (Exception exception)
            {
                AddIOException(exception);
                return string.Empty;
            }
        }
        /// <summary>
        /// 判断路径是否存在
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static bool DirectoryExit(this string dir)
        {
            if (dir.IsDirectory())
            {
                return Directory.Exists(dir);
            }
            else
            {
                AddIOException(new Exception($"路径不合法({dir})!"));
            }
            return false;
        }
        /// <summary>
        /// 创建路径
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static Exception CreateDirectory(this string dir)
        {
            try
            {
                if (dir.IsDirectory())
                {
                    if (!dir.DirectoryExit())
                    {
                        Directory.CreateDirectory(dir);
                    }
                    return default;
                }
                else
                {
                    return AddIOException(new Exception($"路径不合法({dir})!"));
                }
            }
            catch (Exception ioExcetpion)
            {
                return AddIOException(ioExcetpion);
            }
        }
        /// <summary>
        /// 是否是文件路径
        /// </summary>
        /// <param name="path"></param>
        /// <param name="hasSuffix"></param>
        /// <returns></returns>
        public static bool IsFilePath(this string path)
        {
            try
            {
                if (Path.GetDirectoryName(path)?.Length > 0
                    && Path.GetFileName(path)?.Length > 0
                    && Path.GetPathRoot(path)?.Length > 0)
                {
                    return default != new FileInfo(path).Directory;
                }
                return false;
            }
            catch (Exception exception)
            {
                AddIOException(exception);
                return false;
            }
        }
        /// <summary>
        /// 判断文件是否存在
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool FileExit(this string path)
        {
            if (path.IsFilePath())
            {
                return File.Exists(path);
            }
            else
            {
                AddIOException(new Exception($"文件路径名称不合法({path})!"));
            }
            return false;
        }
        /// <summary>
        /// 创建文件如果不允许覆盖
        /// 则将isOverride设置为false
        /// </summary>
        /// <param name="path"></param>
        /// <param name="isOverride"></param>
        /// <returns></returns>
        public static Exception CreateFile(this string path, bool isOverride = true)
        {
            if (path.IsFilePath())
            {
                var dir = path.GetDirectory();
                var s = dir.DirectoryExit();
                if (!string.IsNullOrEmpty(dir))
                    if (!dir.DirectoryExit())
                        if (dir.CreateDirectory() is Exception ioException)
                            return ioException;
                try
                {
                    if (TryLockUsingFilePath(path) is Exception fileException)
                        return fileException;
                    if (isOverride
                        || !isOverride
                        && !path.FileExit())
                    {
                        File.Create(path).Close();
                        File.WriteAllText(path, string.Empty);
                    }
                    else
                    {
                        if (!isOverride
                            && path.FileExit())
                        {
                            return AddIOException(new Exception($"文件已经存在({path})!"));
                        }
                    }
                }
                catch (Exception exception)
                {
                    return AddIOException(exception);
                }
                finally
                {
                    UnlockUsingFilePath(path);
                }
            }
            return default;
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Exception DeleteFile(this string path)
        {
            if (path.IsFilePath())
            {
                var dir = path.GetDirectory();
                if (!string.IsNullOrEmpty(dir))
                    if (!dir.DirectoryExit())
                        if (dir.CreateDirectory() is Exception ioException)
                            return ioException;
                try
                {
                    if (TryLockUsingFilePath(path) is Exception fileException)
                        return fileException;
                    File.Delete(path);
                }
                catch (Exception exception)
                {
                    return AddIOException(exception);
                }
                finally
                {
                    UnlockUsingFilePath(path);
                }
            }
            return default;
        }
        /// <summary>
        /// 大数据文件分步读取时
        /// 缓存大小
        /// 在ReadText使用
        /// 默认1M 1024*1024
        /// </summary>
        public static int SingleStringBufferCapacity { get; set; } = 1024 * 1024;
        /// <summary>
        /// 读取文件
        /// 非64位系统将x86置为true防止stringbuilder溢出造成的异常
        /// </summary>
        /// <param name="path"></param>
        /// <param name="encoding"></param>
        /// <param name="isX86"></param>
        /// <returns></returns>
        public static string ReadText(this string path, Encoding encoding = default, bool isX86 = false)
        {
            if (path.IsFilePath())
            {
                if (!path.FileExit())
                    if (path.CreateFile() is Exception fileException)
                        if (AddIOException(fileException) is Exception addIOException)
                            throw addIOException;
                if (TryLockUsingFilePath(path) is Exception trylockException)
                    throw trylockException;
                else
                {
                    try
                    {
                        encoding = encoding ?? Encodings.UTF8;
                        var readText = string.Empty;
                        var readTextSB = new StringBuilder();
                        // 构造读取文件流对象
                        using (FileStream fsRead = new FileStream(path, FileMode.OpenOrCreate)) //打开文件，不能创建新的
                        {
                            //开辟临时缓存内存
                            byte[] byteArrayRead = new byte[1024 * 1024]; //  1字节*1024 = 1k 1k*1024 = 1M内存
                                                                          //通过死缓存去读文本中的内容
                            while (true)
                            {
                                //readCount  这个是保存真正读取到的字节数
                                int readCount = fsRead.Read(byteArrayRead, 0, byteArrayRead.Length);
                                if (isX86)
                                    readText += encoding.GetString(byteArrayRead, 0, readCount);
                                else
                                    readTextSB.Append(encoding.GetString(byteArrayRead, 0, readCount));
                                //既然是死循环 那么什么时候我们停止读取文本内容 我们知道文本最后一行的大小肯定是小于缓存内存大小的
                                if (readCount < byteArrayRead.Length)
                                {
                                    break;  //结束循环
                                }
                            }
                        }
                        if (!isX86)
                        {
                            readText = readTextSB.ToString();
                        }
                        return readText;
                    }
                    catch (Exception ioException)
                    {
                        throw AddIOException(ioException);
                    }
                    finally
                    {
                        UnlockUsingFilePath(path);
                    }
                }
            }
            return string.Empty;
        }
        /// <summary>
        /// 大数据文件分步写入时触发的单个字符长度
        /// 在WriteAppendText使用
        /// </summary>
        public static int SingleStringCapacity { get; set; } = 30000;
        /// <summary>
        /// 写入文本如果已有文件存在则覆盖文本
        /// 正常时异常为空
        /// 失败时返回异常
        /// </summary>
        /// <returns></returns>
        public static Exception WriteText(this string path, string content, Encoding encoding = default)
        {
            if (path.IsFilePath())
            {
                //不管是否已经存在都将文本清空创建一个新的文件
                if (path.CreateFile() is Exception fileException)
                    return AddIOException(fileException);
                if (TryLockUsingFilePath(path) is Exception exception)
                    return exception;
                var writeException = default(Exception);
                try
                {
                    int contentLength = content.Length;//文本长度                        
                    encoding = encoding ?? Encodings.UTF8;
                    if (contentLength > 0)
                    {
                        int stringStepLength = SingleStringCapacity;//每一万个字符进行一次写入操作
                        int remainLength = contentLength;//剩余未写入长度
                        // 构造读取文件流对象
                        using (FileStream fsWrite = new FileStream(path, FileMode.OpenOrCreate)) //打开文件，不能创建新的
                        {
                            //已写入的长度
                            int writeLength = 0;
                            //通过死缓存去读文本中的内容
                            while (remainLength > 0)
                            {
                                var cutLen = stringStepLength;
                                remainLength = contentLength - writeLength;
                                if (remainLength <= stringStepLength)
                                {
                                    if (contentLength < stringStepLength)
                                    {
                                        remainLength = 0;
                                        cutLen = contentLength;
                                    }
                                    else if (contentLength > stringStepLength)
                                    {
                                        remainLength = 0;
                                        cutLen = contentLength % stringStepLength;
                                    }
                                }
                                if (cutLen <= 0)
                                    break;
                                var writeBytes = encoding.GetBytes(content.Substring(writeLength, cutLen));
                                fsWrite.Write(writeBytes, 0, writeBytes.Length);
                                writeLength += cutLen;
                            }
                        }
                    }
                }
                catch (Exception ioException)
                {
                    writeException = AddIOException(ioException);
                }
                finally
                {
                    UnlockUsingFilePath(path);
                }
                return writeException;
            }
            return new Exception("文件路径不合法!");
        }

        /// <summary>
        /// 写入文本如果已有文件存在则覆盖文本
        /// 正常时异常为空
        /// 失败时返回异常
        /// </summary>
        /// <returns></returns>
        public static Exception AppendText(this string path, string content, Encoding encoding = default)
        {
            if (path.IsFilePath())
            {
                if (!path.FileExit())
                    if (path.CreateFile() is Exception fileException)
                        return AddIOException(fileException);
                if (TryLockUsingFilePath(path) is Exception exception)
                    return exception;
                var writeException = default(Exception);
                try
                {
                    int contentLength = content.Length;//文本长度                        
                    encoding = encoding ?? Encodings.UTF8;
                    if (contentLength > 0)
                    {
                        int stringStepLength = SingleStringCapacity;//每30000个字符进行一次写入操作
                        int remainLength = contentLength;//剩余未写入长度
                        // 构造读取文件流对象
                        using (FileStream fsWrite = new FileStream(path, FileMode.OpenOrCreate)) //打开文件，不能创建新的
                        {
                            //将起始位置定位到当前文件的末尾
                            fsWrite.Position = fsWrite.Length;
                            //已写入的长度
                            int writeLength = 0;
                            //通过死缓存去读文本中的内容
                            while (remainLength > 0)
                            {
                                var cutLen = stringStepLength;
                                remainLength = contentLength - writeLength;
                                if (remainLength <= stringStepLength)
                                {
                                    if (contentLength < stringStepLength)
                                    {
                                        remainLength = 0;
                                        cutLen = contentLength;
                                    }
                                    else if (contentLength > stringStepLength)
                                    {
                                        remainLength = 0;
                                        cutLen = contentLength % stringStepLength;
                                    }
                                }
                                if (cutLen <= 0)
                                    break;
                                var writeBytes = encoding.GetBytes(content.Substring(writeLength, cutLen));
                                fsWrite.Write(writeBytes, 0, writeBytes.Length);
                                writeLength += cutLen;
                            }
                        }
                    }
                }
                catch (Exception ioException)
                {
                    writeException = AddIOException(ioException);
                }
                finally
                {
                    UnlockUsingFilePath(path);
                }
                return writeException;
            }
            return new Exception("文件路径不合法!");
        }
        /// <summary>
        /// 路径绝对化
        /// 如果是~开头的相对路径则获取当前路径并生成完整路径
        /// 如果是一个绝对路径则返回本身
        /// </summary>
        /// <param name="path"></param>
        /// <param name="dir">绝对路径的路径</param>
        /// <returns></returns>
        public static string AbsolutePath(this string path, string dir = null)
        {
            if (path.Length > 1)
            {
                if (strings.ENLeftBookTitle == path.Substring(0, 1))
                {
                    dir = string.IsNullOrEmpty(dir?.Trim()) ?
                        AppDomain.CurrentDomain.BaseDirectory : dir;
                    path = $@"{dir}\{path.Substring(1, path.Length - 1)}".Replace(@"\\\", @"\").Replace(@"\\", @"\");
                }
            }
            if (path.IsFilePath())
            {
                return path;
            }
            return string.Empty;
        }
    }
}
