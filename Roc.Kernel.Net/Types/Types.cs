using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Roc.Kernel
{
    /// <summary>
    /// 常用类型
    /// </summary>
    public static partial class Types
    {
        public static readonly object ms_AnsycLock = new object();
        /// <summary>
        /// IConvertible
        /// </summary>
        public static Type IConvertible { get; } = typeof(IConvertible);
        /// <summary>
        /// IList类型
        /// </summary>
        public static Type IList { get; } = typeof(IList);
        /// <summary>
        /// IList<T>类型
        /// </summary>
        public static Type IListT { get; } = typeof(IList<>);
        /// <summary>
        /// List<T>类型
        /// </summary>
        public static Type ListT { get; } = typeof(List<>);
        /// <summary>
        /// Guid
        /// </summary>
        public static Type Guid { get; } = typeof(Guid);
        /// <summary>
        /// Guid?
        /// </summary>
        public static Type GuidNullable { get; } = typeof(Guid?);
        /// <summary>
        /// 所有Guid类型 private
        /// </summary>
        static List<Type> ms_Guids;
        /// <summary>
        /// 所有Guid类型
        /// </summary>
        public static List<Type> Guids
        {
            get
            {
                lock (ms_AnsycLock)
                {
                    if (ms_Guids == null)
                    {
                        ms_Guids = new List<Type>()
                        {
                            Guid,
                            GuidNullable,
                        };
                    }
                    return ms_Guids;
                }
            }
        }
        /// <summary>
        /// 枚举类型
        /// </summary>
        public static Type Enum { get; } = typeof(Enum);
        /// <summary>
        /// System.Drawing.Color
        /// </summary>
        public static Type DrawingColor { get; } = typeof(System.Drawing.Color);
        /// <summary>
        /// System.Drawing.Color?
        /// </summary>
        public static Type DrawingColorNullable { get; } = typeof(System.Drawing.Color?);
        /// <summary>
        /// System.Windows.Media.Color
        /// </summary>
        public static Type MediaColor { get; } = typeof(System.Windows.Media.Color);
        /// <summary>
        /// System.Windows.Media.Color?
        /// </summary>
        public static Type MediaColorNullable { get; } = typeof(System.Windows.Media.Color?);
        /// <summary>
        /// 所有DrawingColor类型 private
        /// </summary>
        static List<Type> ms_DrawingColors;
        /// <summary>
        /// 所有System.Drawing.DrawingColor类型
        /// </summary>
        public static List<Type> DrawingColors
        {
            get
            {
                lock (ms_AnsycLock)
                {
                    if (ms_DrawingColors == null)
                    {
                        ms_DrawingColors = new List<Type>()
                        {
                            DrawingColor,
                            DrawingColorNullable,
                        };
                    }
                    return ms_DrawingColors;
                }
            }
        }
        /// <summary>
        /// 所有MediaColor类型 private
        /// </summary>
        static List<Type> ms_MediaColors;
        /// <summary>
        /// 所有System.Drawing.MediaColor类型
        /// </summary>
        public static List<Type> MediaColors
        {
            get
            {
                lock (ms_AnsycLock)
                {
                    if (ms_MediaColors == null)
                    {
                        ms_MediaColors = new List<Type>()
                        {
                            MediaColor,
                            MediaColorNullable,
                        };
                    }
                    return ms_MediaColors;
                }
            }
        }
        /// <summary>
        /// 所有Color类型 private
        /// </summary>
        static List<Type> ms_Colors;
        /// <summary>
        /// 所有System.Drawing.Color类型
        /// </summary>
        public static List<Type> Colors
        {
            get
            {
                lock (ms_AnsycLock)
                {
                    if (ms_Colors == null)
                    {
                        ms_Colors = new List<Type>()
                        {
                            DrawingColor,
                            DrawingColorNullable,
                            MediaColor,
                            MediaColorNullable,
                        };
                    }
                    return ms_Colors;
                }
            }
        }
        internal static List<Type> ms_ValuesTypes;
        /// <summary>
        /// 值类型
        /// </summary>
        public static List<Type> ValuesTypes
        {
            get
            {
                lock (ms_AnsycLock)
                {
                    if (ms_ValuesTypes == null)
                    {
                        ms_ValuesTypes = new List<Type>();
                        ms_ValuesTypes.AddRange(NumbericTypes);
                        ms_ValuesTypes.AddRange(Strings);
                        ms_ValuesTypes.AddRange(Bools);
                        ms_ValuesTypes.AddRange(DateTimes);
                        ms_ValuesTypes.AddRange(Colors);
                    }
                    return ms_ValuesTypes;
                }
            }
        }
        /// <summary>
        /// 数字类型
        /// </summary>
        internal static List<Type> ms_NumbericTypes;
        /// <summary>
        /// 数字类型
        /// </summary>
        public static List<Type> NumbericTypes
        {
            get
            {
                lock (ms_AnsycLock)
                {
                    if (ms_NumbericTypes == null)
                    {
                        ms_NumbericTypes = new List<Type>();
                        ms_NumbericTypes.AddRange(Floats);
                        ms_NumbericTypes.AddRange(Doubles);
                        ms_NumbericTypes.AddRange(Decimals);
                        ms_NumbericTypes.AddRange(Bytes);
                        ms_NumbericTypes.AddRange(SBytes);
                        ms_NumbericTypes.AddRange(Shorts);
                        ms_NumbericTypes.AddRange(UShorts);
                        ms_NumbericTypes.AddRange(Ints);
                        ms_NumbericTypes.AddRange(UInts);
                        ms_NumbericTypes.AddRange(Longs);
                        ms_NumbericTypes.AddRange(ULongs);
                    }
                    return ms_NumbericTypes;
                }
            }
        }
        /// <summary>
        /// object
        /// </summary>
        public static Type @object { get; } = typeof(object);
        /// <summary>
        /// char
        /// U+0000 到 U+ffff
        /// </summary>
        public static Type @char { get; } = typeof(char);
        /// <summary>
        /// char?
        /// U+0000 到 U+ffff
        /// </summary>
        public static Type charNullable { get; } = typeof(char?);
        /// <summary>
        /// 所有char类型 private
        /// </summary>
        static List<Type> ms_Chars;
        /// <summary>
        /// 所有char类型
        /// </summary>
        public static List<Type> Chars
        {
            get
            {
                lock (ms_AnsycLock)
                {
                    if (ms_Chars == null)
                    {
                        ms_Chars = new List<Type>()
                        {
                            @char,
                            charNullable,
                        };
                    }
                    return ms_Chars;
                }
            }
        }
        /// <summary>
        /// bool
        /// </summary>
        public static Type @bool { get; } = typeof(bool);
        /// <summary>
        /// bool?
        /// </summary>
        public static Type boolNullable { get; } = typeof(bool?);
        /// <summary>
        /// 所有bool类型 private
        /// </summary>
        static List<Type> ms_Bools;
        /// <summary>
        /// 所有bool类型
        /// </summary>
        public static List<Type> Bools
        {
            get
            {
                lock (ms_AnsycLock)
                {
                    if (ms_Bools == null)
                    {
                        ms_Bools = new List<Type>()
                        {
                            @bool,
                            boolNullable,
                        };
                    }
                    return ms_Bools;
                }
            }
        }
        /// <summary>
        /// 时间
        /// </summary>
        public static Type DateTime { get; } = typeof(DateTime);
        /// <summary>
        /// 时间?
        /// </summary>
        public static Type DateTimeNullable { get; } = typeof(DateTime?);
        /// <summary>
        /// 所有DateTime类型 private
        /// </summary>
        static List<Type> ms_DateTimes;
        /// <summary>
        /// 所有DateTime类型
        /// </summary>
        public static List<Type> DateTimes
        {
            get
            {
                lock (ms_AnsycLock)
                {
                    if (ms_DateTimes == null)
                    {
                        ms_DateTimes = new List<Type>()
                        {
                            DateTime,
                            DateTimeNullable,
                        };
                    }
                }
                return ms_DateTimes;
            }
        }
        /// <summary>
        /// 32位有符号整数
        /// -2,147,483,648 到 2,147,483,647
        /// </summary>
        public static Type @int { get; } = typeof(int);
        /// <summary>
        /// 32位有符号整数?
        /// -2,147,483,648 到 2,147,483,647
        /// </summary>
        public static Type intNullable { get; } = typeof(int?);
        /// <summary>
        /// 所有Int类型 private
        /// </summary>
        static List<Type> ms_Ints;
        /// <summary>
        /// 所有Int类型
        /// </summary>
        public static List<Type> Ints
        {
            get
            {
                lock (ms_AnsycLock)
                {
                    if (ms_Ints == null)
                    {
                        ms_Ints = new List<Type>()
                        {
                            @int,
                            intNullable,
                        };
                    }
                    return ms_Ints;
                }
            }
        }
        /// <summary>
        /// 32位无符号整数
        /// 0 到 4,294,967,295
        /// </summary>
        public static Type @uint { get; } = typeof(uint);
        /// <summary>
        /// 32位无符号整数?
        /// 0 到 4,294,967,295
        /// </summary>
        public static Type uintNullable { get; } = typeof(uint?);

        /// <summary>
        /// 所有UInt类型 private
        /// </summary>
        static List<Type> ms_UInts;
        /// <summary>
        /// 所有UInt类型
        /// </summary>
        public static List<Type> UInts
        {
            get
            {
                lock (ms_AnsycLock)
                {
                    if (ms_UInts == null)
                    {
                        ms_UInts = new List<Type>()
                        {
                            @uint,
                            uintNullable,
                        };
                    }
                    return ms_UInts;
                }
            }
        }

        /// <summary>
        /// 小数float(精度为7位有效数字)
        /// ±1.5 × 10−45 to ±3.4 × 1038
        /// </summary>
        public static Type @float { get; } = typeof(float);
        /// <summary>
        /// 小数float(精度为7位有效数字)?
        /// ±1.5 × 10−45 to ±3.4 × 1038
        /// </summary>
        public static Type floatNullable { get; } = typeof(float?);
        /// <summary>
        /// 所有Float类型 private
        /// </summary>
        static List<Type> ms_Floats;
        /// <summary>
        /// 所有Float类型
        /// </summary>
        public static List<Type> Floats
        {
            get
            {
                lock (ms_AnsycLock)
                {
                    if (ms_Floats == null)
                    {
                        ms_Floats = new List<Type>()
                        {
                            @float,
                            floatNullable,
                        };
                    }
                    return ms_Floats;
                }
            }
        }
        /// <summary>
        /// 小数double(精度为15位有效数字)
        /// ±5.0 × 10 −324 to ±1.7 × 10308
        /// </summary>
        public static Type @double { get; } = typeof(double);
        /// <summary>
        /// 小数double(精度为15位有效数字)?
        /// ±5.0 × 10 −324 to ±1.7 × 10308
        /// </summary>
        public static Type doubleNullable { get; } = typeof(double?);
        /// <summary>
        /// 所有Double类型 private
        /// </summary>
        static List<Type> ms_Doubles;
        /// <summary>
        /// 所有Double类型
        /// </summary>
        public static List<Type> Doubles
        {
            get
            {
                lock (ms_AnsycLock)
                {
                    if (ms_Doubles == null)
                    {
                        ms_Doubles = new List<Type>()
                        {
                            @double,
                            doubleNullable,
                        };
                    }
                    return ms_Doubles;
                }
            }
        }
        /// <summary>
        /// 小数decimal(最大精度到28位)
        /// ±1.0 × 10−28 to ±7.9 × 1028
        /// </summary>
        public static Type @decimal { get; } = typeof(decimal);
        /// <summary>
        /// 小数decimal(最大精度到28位)?
        /// ±1.0 × 10−28 to ±7.9 × 1028
        /// </summary>
        public static Type decimalNullable { get; } = typeof(decimal?);
        /// <summary>
        /// 所有Decimal类型 private
        /// </summary>
        static List<Type> ms_Decimals;
        /// <summary>
        /// 所有Decimal类型
        /// </summary>
        public static List<Type> Decimals
        {
            get
            {
                lock (ms_AnsycLock)
                {
                    if (ms_Decimals == null)
                    {
                        ms_Decimals = new List<Type>()
                        {
                            @decimal,
                            decimalNullable,
                        };
                    }
                    return ms_Decimals;
                }
            }
        }
        /// <summary>
        /// string
        /// </summary>
        public static Type @string { get; } = typeof(string);
        /// <summary>
        /// StringBuilder
        /// </summary>
        public static Type StringBuilder { get; } = typeof(StringBuilder);
        /// <summary>
        /// 所有string类型 private
        /// </summary>
        static List<Type> ms_Strings;
        /// <summary>
        /// 所有string类型
        /// </summary>
        public static List<Type> Strings
        {
            get
            {
                lock (ms_AnsycLock)
                {
                    if (ms_Strings == null)
                    {
                        ms_Strings = new List<Type>()
                        {
                            @string,
                            StringBuilder,
                        };
                    }
                    return ms_Strings;
                }
            }
        }
        /// <summary>
        /// 有符号16位整数
        /// -32,768 到 32,767
        /// </summary>
        public static Type @short { get; } = typeof(short);
        /// <summary>
        /// 有符号16位整数
        /// -32,768 到 32,767
        /// </summary>
        public static Type shortNullable { get; } = typeof(short?);
        /// <summary>
        /// 所有Short类型 private
        /// </summary>
        static List<Type> ms_Shorts;
        /// <summary>
        /// 所有Short类型
        /// </summary>
        public static List<Type> Shorts
        {
            get
            {
                lock (ms_AnsycLock)
                {
                    if (ms_Shorts == null)
                    {
                        ms_Shorts = new List<Type>()
                        {
                            @short,
                            shortNullable,
                        };
                    }
                    return ms_Shorts;
                }
            }
        }
        /// <summary>
        /// 无符号16位整数
        /// 0 到 65,535
        /// </summary>
        public static Type @ushort { get; } = typeof(ushort);
        /// <summary>
        /// 无符号16位整数?
        /// 0 到 65,535
        /// </summary>
        public static Type ushortNullable { get; } = typeof(ushort?);
        /// <summary>
        /// 所有UShort类型 private
        /// </summary>
        static List<Type> ms_UShorts;
        /// <summary>
        /// 所有UShort类型
        /// </summary>
        public static List<Type> UShorts
        {
            get
            {
                lock (ms_AnsycLock)
                {
                    if (ms_UShorts == null)
                    {
                        ms_UShorts = new List<Type>()
                        {
                            @ushort,
                            ushortNullable,
                        };
                    }
                    return ms_UShorts;
                }
            }
        }
        /// <summary>
        /// 有符号64位整数
        /// -9,223,372,036,854,775,808 到 9,223,372,036,854,775,807
        /// </summary>
        public static Type @long { get; } = typeof(long);
        /// <summary>
        /// 有符号64位整数?
        /// -9,223,372,036,854,775,808 到 9,223,372,036,854,775,807
        /// </summary>
        public static Type longNullable { get; } = typeof(long?);
        /// <summary>
        /// 所有Long类型 private
        /// </summary>
        static List<Type> ms_Longs;
        /// <summary>
        /// 所有Long类型
        /// </summary>
        public static List<Type> Longs
        {
            get
            {
                lock (ms_AnsycLock)
                {
                    if (ms_Longs == null)
                    {
                        ms_Longs = new List<Type>()
                        {
                            @long,
                            longNullable,
                        };
                    }
                    return ms_Longs;
                }
            }
        }
        /// <summary>
        ///无符号64位整数
        ///0 到 18,446,744,073,709,551,615
        /// </summary>
        public static Type @ulong { get; } = typeof(ulong);
        /// <summary>
        /// 无符号64位整数?
        /// 0 到 18,446,744,073,709,551,615
        /// </summary>
        public static Type ulongNullable { get; } = typeof(ulong?);
        /// <summary>
        /// 所有ULong类型 private
        /// </summary>
        static List<Type> ms_ULongs;
        /// <summary>
        /// 所有ULong类型
        /// </summary>
        public static List<Type> ULongs
        {
            get
            {
                lock (ms_AnsycLock)
                {
                    if (ms_ULongs == null)
                    {
                        ms_ULongs = new List<Type>()
                        {
                            @ulong,
                            ulongNullable,
                        };
                    }
                    return ms_ULongs;
                }
            }
        }
        /// <summary>
        /// 无符号字节
        /// (0-255)
        /// </summary>
        public static Type @byte { get; } = typeof(byte);
        /// <summary>
        /// 无符号字节
        /// (0-255)?
        /// </summary>
        public static Type byteNullable { get; } = typeof(byte?);
        /// <summary>
        /// 所有Byte类型 private
        /// </summary>
        static List<Type> ms_Bytes;
        /// <summary>
        /// 所有Byte类型
        /// </summary>
        public static List<Type> Bytes
        {
            get
            {
                lock (ms_AnsycLock)
                {
                    if (ms_Bytes == null)
                    {
                        ms_Bytes = new List<Type>()
                        {
                            @byte,
                            byteNullable,
                        };
                    }
                    return ms_Bytes;
                }
            }
        }
        /// <summary>
        /// 有符号字节
        /// (-127-128)
        /// </summary>
        public static Type @sbyte { get; } = typeof(sbyte);
        /// <summary>
        /// 有符号字节
        /// (-127-128)?
        /// </summary>
        public static Type sbyteNullable { get; } = typeof(sbyte?);
        /// <summary>
        /// 所有SByte类型 private
        /// </summary>
        static List<Type> ms_SBytes;
        /// <summary>
        /// 所有SByte类型
        /// </summary>
        public static List<Type> SBytes
        {
            get
            {
                lock (ms_AnsycLock)
                {
                    if (ms_SBytes == null)
                    {
                        ms_SBytes = new List<Type>()
                        {
                            @sbyte,
                            sbyteNullable,
                        };
                    }
                    return ms_SBytes;
                }
            }
        }
    }
}
