using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roc.Kernel.Attributes;

namespace Roc.Kernel
{
    /// <summary>
    /// 常用字符定义
    /// </summary>
    public static partial class strings
    {
        //FTP是文件传输协议的简称，FTP地址格式bai应该是
        //ftp://用户名:密码@IP地址或者域名:端口号
        //若设置为可以匿名访问且端口号为21，直接用
        //ftp://IP地址或者域名
        #region Web 网络相关
        /// <summary>
        /// 协议分隔符 ://
        /// </summary>
        [Sign("Web")]
        public static string ProtocolSeparator = "://";
        /// <summary>
        /// Https协议 https
        /// </summary>
        [Sign("Web")]
        public static string Https { get; } = @"https";
        /// <summary>
        /// Http协议 http
        /// </summary>
        [Sign("Web")]
        public static string Http { get; } = @"http";
        /// <summary>
        /// Ftp协议 ftp
        /// </summary>
        [Sign("Web")]
        public static string Ftp { get; } = @"ftp";
        /// <summary>
        /// DotCom .com
        /// </summary>
        [Sign("Web")]
        public static string DotCom { get; } = @".com";
        /// <summary>
        /// DotNet .com
        /// </summary>
        [Sign("Web")]
        public static string DotNet { get; } = @".net";
        /// <summary>
        /// At @
        /// </summary>
        [Sign("Normal-Web")]
        public static string At { get; } = @"@";
        #endregion
       
        #region EN
        /// <summary>
        /// 英文等于号 =
        /// </summary>
        public static string ENEqual { get; } = "=";
        /// <summary>
        /// 英文井号 #
        /// </summary>
        public static string ENNumberSign { get; } = "#";
      
        /// <summary>
        /// 正负号 ±
        /// </summary>
        public static string PlusOrMinus { get; } = "±";
        /// <summary>
        /// 英文正斜杠 /
        /// </summary>
        public static string ENForwardSlash { get; } = "/";

        /// <summary>
        /// 英文百分号 ％
        /// </summary>
        public static string ENPercent { get; } = "％";
        /// <summary>
        /// 英文千分号 ‰
        /// </summary>
        public static string ENPermill { get; } = "‰";
        /// <summary>
        /// 英文万分号 ‱
        /// </summary>
        public static string ENPermyriad { get; } = "‱";
        //backslash
        /// <summary>
        /// 英文反斜杠 \
        /// </summary>
        public static string ENBackSlash { get; } = "\\";

        /// <summary>
        /// 英文双引号 "
        /// </summary>
        public static string ENDoubleQuotationMarks { get; } = "\"";

        /// <summary>
        /// 英文冒号 :
        /// </summary>
        public static string ENColon { get; } = ":";

        /// <summary>
        /// 英文分号 ;
        /// </summary>
        public static string ENSemicolon { get; } = ";";

        /// <summary>
        /// 英文逗号 ,
        /// </summary>
        public static string ENComma { get; } = ",";

        /// <summary>
        /// 英文句号 .
        /// </summary>
        public static string ENPeriod { get; } = ".";

        /// <summary>
        /// 空格 ENSpace
        /// </summary>
        public static string ENSpace { get; } = " ";

        /// <summary>
        /// 单引号 '
        /// </summary>
        public static string ENSingleQuotation { get; } = "'";

        /// <summary>
        /// 大括号左 {
        /// </summary>
        public static string ENBraceLeft { get; } = @"{";

        /// <summary>
        /// 大括号右 }
        /// </summary>
        public static string ENBraceRight { get; } = @"}";

        /// <summary>
        /// 方括号左 [
        /// </summary>
        public static string ENSquareBracketLeft { get; } = @"[";

        /// <summary>
        /// 方括号右 ]
        /// </summary>
        public static string ENSquareBracketRight { get; } = @"]";       

        /// <summary>
        /// 括号左 (
        /// </summary>
        public static string ENBracketLeft { get; } = @"(";

        /// <summary>
        /// 括号右 )
        /// </summary>
        public static string ENBracketRight { get; } = @")";

        /// <summary>
        /// 星号 *
        /// </summary>
        public static string ENAsterisk { get; } = @"*";

        /// <summary>
        /// 问号 ?
        /// </summary>
        public static string ENQuestionMark { get; } = @"?";
        /// <summary>
        /// 感叹号 !
        /// </summary>
        public static string ExclamationMark { get; } = @"!";
        /// <summary>
        /// 单竖杠 |
        /// </summary>
        public static string ENVerticalBar { get; } = @"|";

        /// <summary>
        /// 脱字号  补注号 ^
        /// </summary>
        public static string ENCaret { get; } = @"^";
        /// <summary>
        /// 右书名号 <
        /// </summary>
        public static string ENRightBookTitle { get; } = @"<";

        /// <summary>
        /// 左书名号 >
        /// </summary>
        public static string ENLeftBookTitle { get; } = @">";

        /// <summary>
        /// 波浪号 ~
        /// </summary>
        public static string ENTilde { get; } = @"~";


        /// <summary>
        /// 取反 ~
        /// 波浪号
        /// </summary>
        public static string ENNegate { get; } = ENTilde;




        #endregion

        #region LogicalSigns 逻辑运算符
        #region LogicalSigns 逻辑运算符 in VS
        /// <summary>
        /// 与 &
        /// 逻辑门符号 VS中
        /// </summary>
        [Sign("VS-Logical")]
        public static string VSAND { get; } = @"&";

        /// <summary>
        /// 或 |
        /// 逻辑门符号 VS中
        /// </summary>
        [Sign("VS-Logical")]
        public static string VSOR { get; } = ENVerticalBar;

        //XOR、eor、⊕
        /// <summary>
        /// 非 !
        /// 逻辑门符号 VS中
        /// </summary>
        [Sign("VS-Logical")]
        public static string VSNOT { get; } = ExclamationMark;

        /// <summary>
        /// 异或 ^
        /// 逻辑门符号 VS中
        /// </summary>
        [Sign("VS-Logical")]
        public static string VSXOR { get; } = ENCaret;
        #endregion

        #region LogicalSigns 逻辑运算符 Normal
        /// <summary>
        /// 与 AND
        /// 逻辑门符号
        /// </summary>
        [Sign("Logical")]
        public static string AND { get; } = @"AND";

        /// <summary>
        /// 或 OR
        /// 逻辑门符号
        /// </summary>
        [Sign("Logical")]
        public static string OR { get; } = @"OR";

        //XOR、eor、⊕
        /// <summary>
        /// 非 NOT
        /// 逻辑门符号
        /// </summary>
        [Sign("Logical")]
        public static string NOT { get; } = @"NOT";

        /// <summary>
        /// 异或 XOR
        /// 逻辑门符号
        /// </summary>
        [Sign("Logical")]
        public static string XOR { get; } = @"XOR";
        #endregion
        #endregion

        #region Compare比较符号
        /// <summary>
        /// 英文不等于号 !=
        /// </summary>
        [Sign("Logical-Compare")]
        public static string ENNotEqual { get; } = "!=";
        /// <summary>
        /// ANSI标准中的不等于号 <>
        /// </summary>
        [Sign("Logical-Compare")]
        public static string ANSINotEqual { get; } = "<>";
        /// <summary>
        /// 大于号 >
        /// </summary>
        [Sign("Logical-Compare")]
        public static string GreaterThan { get; } = ENRightBookTitle;

        /// <summary>
        /// 小于号 <
        /// </summary>
        [Sign("Logical-Compare")]
        public static string LessThan { get; } = ENLeftBookTitle;
        /// <summary>
        /// 大于等于号 >=
        /// </summary>
        [Sign("Logical-Compare")]
        public static string GreaterThanOrEqual { get; } = ENRightBookTitle + ENEqual;

        /// <summary>
        /// 小于等于号 <=
        /// </summary>
        [Sign("Logical-Compare")]
        public static string LessThanOrEqual { get; } = ENLeftBookTitle + ENEqual;
        #endregion

        #region ArithmeticFour 常规四则运算 Normal
        /// <summary>
        /// 加号 +
        /// </summary>
        [Sign("Math")]
        public static string Plus { get; } = "+";
        /// <summary>
        /// 减号 -
        /// </summary>
        [Sign("Math")]
        public static string Minus { get; } = "-";
        /// <summary>
        /// 乘号 ×
        /// </summary>
        [Sign("Math")]
        public static string Multiply { get; } = "×";
        /// <summary>
        /// 除号 ÷
        /// </summary>
        [Sign("Math")]
        public static string Divide { get; } = "÷";
        #endregion

        #region ArithmeticFour 常规四则运算 in VS
        /// <summary>
        /// 加号 +
        /// 在VS中
        /// </summary>
        [Sign("VS-Math")]
        public static string VSPlus { get; } = Plus;
        /// <summary>
        /// 减号 -
        /// 在VS中
        /// </summary>
        [Sign("VS-Math")]
        public static string VSMinus { get; } = Minus;
        /// <summary>
        /// 乘号 *
        /// 在VS中
        /// </summary>
        [Sign("VS-Math")]
        public static string VSMultiply { get; } = ENAsterisk;
        /// <summary>
        /// 除号 /
        /// 在VS中
        /// </summary>
        [Sign("VS-Math")]
        public static string VSDivide { get; } = ENForwardSlash;
        #endregion

        #region Lamda 操作符
        /// <summary>
        /// GoTo操作符 =>
        /// </summary>
        [Sign("Lamda")]
        public static string LamdaGoTo { get; } = "=>";

        /// <summary>
        /// += 操作符 
        /// </summary>
        [Sign("Lamda")]
        public static string LamdaPlusEqual { get; } = "+=";

        /// <summary>
        /// ++ 操作符
        /// </summary>
        [Sign("Lamda")]
        public static string LamdaPlusTwice { get; } = "++";

        /// <summary>
        /// -= 操作符
        /// </summary>
        [Sign("Lamda")]
        public static string LamdaMinusEqual { get; } = "-=";

        /// <summary>
        /// -- 操作符
        /// </summary>
        [Sign("Lamda")]
        public static string LamdaMinusTwice { get; } = "--";

        #endregion

        #region Math 进阶运算 Normal
        #region 计算符号 arithmetic
        //±plus or minus 正负号
        /// <summary>
        /// 数学正负号 ±
        /// </summary>
        [Sign("Math")]
        public static string MathPlusOrMinus { get; } = "±";

        /// <summary>
        /// 数学等于 =
        /// </summary>
        [Sign("Math")]
        public static string MathEqual { get; } = "=";

        /// <summary>
        /// 数学不等于 ≠
        /// </summary>
        [Sign("Math")]
        public static string MathNotEqual { get; } = "≠";

        /// <summary>
        /// 数学全等于 ≡
        /// </summary>
        [Sign("Math")]
        public static string MathEquivalent { get; } = "≡";

        /// <summary>
        /// 数学等于或约等于 ≌
        /// </summary>
        [Sign("Math")]
        public static string MathEqualOrApproximatelyEqual { get; } = "≌";

        /// <summary>
        /// 数学约等于 ≈
        /// </summary>
        [Sign("Math")]
        public static string ApproximatelyEqual { get; } = "≈";

        /// <summary>
        /// 不小于号 ≮
        /// </summary>
        [Sign("Math")]
        public static string MathNotLessThan { get; } = @"≮";

        /// <summary>
        /// 不大于号 ≯
        /// </summary>
        [Sign("Math")]
        public static string MathNotGreaterThan { get; } = @"≯";
        /// <summary>
        /// 大于号 >
        /// </summary>
        [Sign("Math")]
        public static string MathGreaterThan { get; } = ENRightBookTitle;

        /// <summary>
        /// 小于号 <
        /// </summary>
        [Sign("Math")]
        public static string MathLessThan { get; } = ENLeftBookTitle;

        /// <summary>
        /// 大于等于号 >=
        /// </summary>
        [Sign("Math")]
        public static string MathGreaterThanOrEqual { get; } = ENRightBookTitle + ENEqual;

        /// <summary>
        /// 小于等于号 <=
        /// </summary>
        [Sign("Math")]
        public static string MathLessThanOrEqual { get; } = ENLeftBookTitle + ENEqual;


        /// <summary>
        /// varies as 与…成比例 ∝
        /// </summary>
        [Sign("Math")]
        public static string MathVariesAs { get; } = "∝";

        /// <summary>
        /// intersection of 并,合集 ∪
        /// </summary>
        [Sign("Math")]
        public static string MathIntersection { get; } = "∪";

        /// <summary>
        /// union of 交,通集 ∩
        /// </summary>
        [Sign("Math")]
        public static string MathUnion { get; } = "∩";


        /// <summary>
        /// the integral of 积分 ∫
        /// </summary>
        [Sign("Math")]
        public static string MathIntegral { get; } = "∫";

        /// <summary>
        /// ∑(sigma) summation of 总和 ∑
        /// </summary>
        [Sign("Math")]
        public static string MathSummation { get; } = "∑";
        #endregion
        #region Math statistical 
        /// <summary>
        /// 均方根值 RMS Root Mean Square
        /// 数组每个值进行平方在平均
        /// 接着开平方
        /// </summary>
        [Sign("Math")]
        public static string MathRootMeanSquare { get; } = "RMS";

        //MSE（Mean Square Error）均方误差

        /// <summary>
        /// 均方误差 MSE Root Mean SquareMSE
        /// 是真实值与预测值的差值的平方然后求和平均
        /// 假设实际测量值为x1 x2 x3 x4 的array
        /// 目标样本值为x1` x2` x3` x4` 的array`
        /// array`与array中每个相同索引的值求差值平方后求和在平均
        /// </summary>
        [Sign("Math")]
        public static string MathMeanSquareError { get; } = "MSE";

        /// <summary>
        /// 均方根误差 方差 RMSE Root Mean Square Error
        /// 衡量观测值与真实值之间的偏差
        /// 假设温度实际值为x1 x2 x3 x4 的array
        /// 实际测量为x1` x2` x3` x4` 的array`
        /// array`与array中每个相同索引的值求差值平方后求和在平均
        /// 最后开方
        /// </summary>
        [Sign("Math")]
        public static string MathRootMeanSquareError { get; } = "RMSE";

        /// <summary>
        /// 标准差 Standard Deviation σ
        /// 计算方法
        /// 求数组平均值
        /// 数组每个值-平均值的求平方和求平均
        /// 开平方
        /// 例：有一组数字分别是200、50、100、200，求它们的样本标准偏差。
        /// x拔= (200+50+100+200)/4 = 550/4 = 137.5
        /// s^2= [(200 - 137.5)^2+(50-137.5)^2+(100-137.5)^2+(200-137.5)^2]/4
        /// 样本标准偏差 S = Sqrt(S ^ 2) = 75
        /// </summary>
        [Sign("Math")]
        public static string MathStandardDeviation { get; } = "σ";



        //1、均方根值（RMS）也称作为效值，它的计算方法是先平方、再平均、然后开方。

        //求得均方根值(RMS)之后原始数组值与RMS相减的值的平方求和再平均最后开方
        //2、均方根误差，它是观测值与真值偏差的平方和观测次数n比值的平方根，在实际测量中，观测次数n总是有限的，
        //真值只能用最可信赖（最佳）值来代替.方根误差对一组测量中的特大或特小误差反映非常敏感，所以，均方根误差能够很好地反映出测量的精密度。
        //均方根误差，当对某一量进行甚多次的测量时，取这一测量列真误差的均方根差(真误差平方的算术平均值再开方)，
        //称为标准偏差，以σ表示。σ反映了测量数据偏离真实值的程度，σ越小，表示测量精度越高，因此可用σ作为评定这一测量过程精度的标准。
        //Root mean square error(RMSE)+Pearson correlation coefficient(r)+Nash-Sutcliffe coefficient(E) 
        //RMSE应该是：误差->平方->平均->开方，平均相对误差也错了，应该是：相对误差->绝对值->平均
        //测量数组Array 求平均值x拔

        //3、标准差（Standard Deviation），标准差是方差的算术平方根，也称均方差（mean square error），
        //是各数据偏离平均数的距离的平均数，它是离均差平方和平均后的方根，用σ表示，标准差能反映一个数据集的离散程度。

        //标准差 测量数组Array 求平均值x拔 

        // 均方根值（RMS）+ 均方根误差（RMSE）+标准差（Standard Deviation
        //标准差σ 标准差（Standard Deviation）
        //傅里叶变换（FFT）和均方根（RMS）均方根误差（RMSE）∮ s∯ ∰ ∬∭ ∏ x̅ 
        //∪intersection of 并,合集
        //∩union of 交,通集
        //∫the integral of …的积分
        //∑(sigma) summation of 总和
        #endregion
        /// <summary>
        /// x拔 x̅
        /// </summary>
        [Sign("Math")]
        public static string MathXBar { get; } = "x̅";

        /// <summary>
        /// 拔符号 "̅"
        /// </summary>
        [Sign("Math-Symbol")]
        public static string MathBar { get; } = "̅";

        /// <summary>
        /// 根号RadicalSign √
        /// </summary>
        [Sign("Math")]
        public static string MathRadicalSign { get; } = "√";

        #region 开根号 PowerRoot √
        /// <summary>
        /// 开平方square-root ²√
        /// </summary>
        [Sign("Math-Power2Root")]
        public static string MathSquareRoot { get; } = "²√";
        /// <summary>
        /// 开立方cube-root ³√
        /// </summary>
        [Sign("Math-Power3Root")]
        public static string MathCubeRoot { get; } = "³√";

        /// <summary>
        /// 开四次方FourthPowerRoot ⁴√
        /// </summary>
        [Sign("Math-Power4Root")]
        public static string MathFourthPowerRoot { get; } = "⁴√";

        /// <summary>
        /// 开五次方FifthPowerRoot ⁵√
        /// </summary>
        [Sign("Math-Power5Root")]
        public static string MathFifthPowerRoot { get; } = "⁵√";

        /// <summary>
        /// 开六次方SixthPowerRoot ⁶√
        /// </summary>
        [Sign("Math-Power6Root")]
        public static string MathSixthPowerRoot { get; } = "⁶√";

        /// <summary>
        /// 开七次方SeventhPowerRoot ⁷√
        /// </summary>
        [Sign("Math-Power7Root")]
        public static string MathSeventhPowerRoot { get; } = "⁷√";

        /// <summary>
        /// 开八次方EighthPowerRoot ⁸√
        /// </summary>
        [Sign("Math-Power8Root")]
        public static string MathEighthPowerRoot { get; } = "⁸√";

        /// <summary>
        /// 开九次方NinethPowerRoot ⁹√
        /// </summary>
        [Sign("Math-Power9Root")]
        public static string MathNinethPowerRoot { get; } = "⁹√";
        #endregion

        #region 指数幂 Power
        /// <summary>
        /// 平方square ²
        /// </summary>
        [Sign("Math-Power2")]
        public static string MathSquare { get; } = "²";

        /// <summary>
        /// 立方cube ³
        /// </summary>
        [Sign("Math-Power3")]
        public static string MathCube { get; } = "³";

        /// <summary>
        /// 四次方FourthPower ⁴
        /// </summary>
        [Sign("Math-Power4")]
        public static string MathFourthPower { get; } = "⁴";

        /// <summary>
        /// 五次方FifthPower ⁵
        /// </summary>
        [Sign("Math-Power5")]
        public static string MathFifthPower { get; } = "⁵";

        /// <summary>
        /// 六次方SixthPower ⁶
        /// </summary>
        [Sign("Math-Power6")]
        public static string MathSixthPower { get; } = "⁶";

        /// <summary>
        /// 七次方SeventhPower ⁷
        /// </summary>
        [Sign("Math-Power7")]
        public static string MathSeventhPower { get; } = "⁷";

        /// <summary>
        /// 八次方EighthPower ⁵
        /// </summary>
        [Sign("Math-Power8")]
        public static string MathEighthPower { get; } = "⁸";

        /// <summary>
        /// 九次方NinethPower ⁹
        /// </summary>
        [Sign("Math-Power9")]
        public static string MathNinethPower { get; } = "⁹";
        #endregion

        #region  Math-Auxiliary 辅助符号 ∵∴等
        //        ∵since; because 因为
        //∴hence 所以
        //∷equals

        /// <summary>
        /// 数学等于,成比例 equals,as (proportion) ∷
        /// </summary>
        [Sign("Math-Auxiliary")]
        public static string MathEqualsAs { get; } = @"∷";

        /// <summary>
        /// 数学因为because ∵
        /// </summary>
        [Sign("Math-Auxiliary")]
        public static string MathBecause { get; } = @"∵";

        /// <summary>
        /// 数学所以hence ∵
        /// </summary>
        [Sign("Math-Auxiliary")]
        public static string MathHence { get; } = @"∴";

        /// <summary>
        /// Math括号左 (
        /// </summary>
        [Sign("Math-Auxiliary")]
        public static string MathBracketLeft { get; } = @"(";

        /// <summary>
        /// 数学括号右 )
        /// </summary>
        [Sign("Math-Auxiliary")]
        public static string MathBracketRight { get; } = @")";

        /// <summary>
        /// 数学大括号左 {
        /// </summary>
        [Sign("Math-Auxiliary")]
        public static string MathBraceLeft { get; } = @"{";

        /// <summary>
        /// 数学大括号右 }
        /// </summary>
        [Sign("Math-Auxiliary")]
        public static string MathBraceRight { get; } = @"}";

        /// <summary>
        /// 数学方括号左 [
        /// </summary>
        [Sign("Math-Auxiliary")]
        public static string MathSquareBracketLeft { get; } = @"[";

        /// <summary>
        /// 数学方括号右 ]
        /// </summary>
        [Sign("Math-Auxiliary")]
        public static string MathSquareBracketRight { get; } = @"]";
        #endregion
        #region Math-Symbol 符号
        /// <summary>
        /// 数学百分号 ％
        /// </summary>
        [Sign("Math-Symbol")]
        public static string MathPercent { get; } = "％";

        /// <summary>
        /// 数学千分号 ‰
        /// </summary>
        [Sign("Math-Symbol")]
        public static string MathPermill { get; } = "‰";

        /// <summary>
        /// 数学万分号 ‱
        /// </summary>
        [Sign("Math-Symbol")]
        public static string MathPermyriad { get; } = "‱";
        #endregion
        #region MathUnit 单位
        /// <summary>
        /// 度 ° angle 
        /// </summary>
        [Sign("Math-Unit")]
        public static string MathDegree { get; } = "°";
        /// <summary>
        /// 分 ′ angle radian
        /// </summary>
        [Sign("Math-Unit")]
        public static string MathMinute { get; } = "′";
        /// <summary>
        /// 秒 ° angle radian
        /// </summary>
        [Sign("Math-Unit")]
        public static string MathSecond { get; } = "“";
        /// <summary>
        /// 弧度 ╭╮angle radian
        /// </summary>
        [Sign("Math-Unit")]
        public static string MathRadian { get; } = "╭╮";
        //( ఠൠఠ )ﾉO(∩_∩)O(；′⌒`)○|￣|_s⌒︵︿︹"◡(‾◡◝)(；′⌒`)（︶^︶）🍳◠◡ ♂♀øØπ@﹫◡";
        #endregion
        /// <summary>
        /// 无穷 ∞
        /// </summary>
        [Sign("Math-Value")]
        public static string MathInfinity { get; } = "∞"; 

        /// <summary>
        /// 正无穷 +∞
        /// </summary>
        [Sign("Math-Value")]
        public static string MathPositiveInfinity { get; } = "+∞";

        /// <summary>
        /// 负无穷 -∞
        /// </summary>
        [Sign("Math-Value")]
        public static string MathNegativeInfinity { get; } = "-∞";
        //∝varies as 与…成比例
        #endregion
    }
}
