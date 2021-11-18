using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace RegexStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "IOS9190203";
            string b = "isos820830";

            //^[a-zA-Z]{3} 确保前3位不区分大小写
            //后面7位是数字
            //方括号"["和花括号"{"
            //方括号"["内时需要匹配的字符，花括号"{"内时指定匹配的字符的数量。
            //圆括号"("则是用来分组的
            Regex obj = new Regex(("^[a-zA-z]{3}[0-9]{7}$"));

            bool isMatch = Regex.IsMatch(a, obj.ToString());
            Console.WriteLine($"${a} isMatch : {isMatch}");
            isMatch = Regex.IsMatch(b, obj.ToString());
            Console.WriteLine($"${b} isMatch : {isMatch}");
            
            //验证简单的网址URL格式
            //第一步 检测是否存在www : ^www.
            //第二步 域名必须是长度在1-15的英文字母: .[a-z]{1-15}
            //第三步 以.com或者.org结束: .{com|org}$
            //圆括号"("则是用来分组的
            a = "www.baidu.com";
            b = "www.baidu.com1";

            obj = new Regex(("^^www[.][a-z]{1,15}[.](com|org)$"));

            isMatch = Regex.IsMatch(a, obj.ToString());
            Console.WriteLine($"${a} isMatch : {isMatch}");
            isMatch = Regex.IsMatch(b, obj.ToString());
            Console.WriteLine($"${b} isMatch : {isMatch}");
            
            //@符号
            //匹配开时 ^
            string str = "I am Blue cat";
            Console.WriteLine(Regex.Replace(str,"^","准备开始"));
            //匹配借宿 $
            str = "I am Blue cat";
            Console.WriteLine(Regex.Replace(str,"$","结束了"));

            string strCheckNum1 = "23423423a3", strCheckNum2 = "324234";
            //校验只允许输入数字
            //^ 开始
            //\d 匹配数字  \将下一个字符标记为一个特殊字符 n匹配字符"n" "\n"匹配一个换行符，序列"\\"匹配"\",而"\("则是匹配"(" 
            //\D 匹配数字的补集 不是数字的一切
            //\D 匹配数字的补集 不是数字的一切
            //*匹配前面的子表达时零次或多次
            //$ 结束
            Console.WriteLine("匹配字符串"+ strCheckNum1 + "是否为数字" + Regex.IsMatch(strCheckNum1,@"^\d*$"));
            Console.WriteLine("匹配字符串"+ strCheckNum2 + "是否为数字" + Regex.IsMatch(strCheckNum2,@"^\d*$"));
            //校验只允许输入除大小写字母，0-9的数字，下划线_以外的任何字符
            //\w 匹配字母，数字，下划线，汉字
            //\W \w的补集
            strCheckNum1 = "abcds_a";
            strCheckNum2 = "**&&((((2";
            string strCheckNum3 = "**&&((((";
            string regexStr = @"^\W*$";
            Console.WriteLine("匹配字符串"+ strCheckNum1 + "是否为除大小写字母，0-9的数字，下划线_以外的任何字符" + Regex.IsMatch(strCheckNum1,regexStr));
            Console.WriteLine("匹配字符串"+ strCheckNum2 + "是否为除大小写字母，0-9的数字，下划线_以外的任何字符" + Regex.IsMatch(strCheckNum2,regexStr));
            Console.WriteLine("匹配字符串"+ strCheckNum3 + "是否为除大小写字母，0-9的数字，下划线_以外的任何字符" + Regex.IsMatch(strCheckNum3,regexStr));
            
            //实例 : 查找除ahou这之外的所有字符
            string strFind1 = "I am a Cat!", strFind2 = "My Name's blue cat!";
            Console.WriteLine("除ahou这之外的所有字符，原字符为:"+ strFind1 + "替换后: " + Regex.Replace(strFind1, 
                    @"[^ahou]","*"));
            Console.WriteLine("除ahou这之外的所有字符，原字符为:"+ strFind2 + "替换后:" + Regex.Replace(strFind2,
                    @"[^ahou]","*"));
            
        }
    }
}