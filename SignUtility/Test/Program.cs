using SignUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 测试产生密钥

            var xmlPrivateKey = "";
            var xmlPublicKey = "";

            SignHelper.RSAKey(out xmlPrivateKey, out xmlPublicKey);


            #endregion

            #region 测试加密
            var encryptString = "我是一个待加密的字符串哟！！！";
            var encryptedString = SignHelper.RSAEncrypt(xmlPublicKey, encryptString);




            #endregion

            #region 测试解密
            var decryptString = encryptedString;
            var encryptString2 = SignHelper.RSADecrypt(xmlPrivateKey, decryptString);

            #endregion

            #region 测试签名
            var strEncryptedSignatureData = "";//签名后的
            var strSource = "2020-10-19 10:21用户张x充值了100元";//待签名字符串
            var strHashbyteSignature = "";//hash
            if(SignHelper.GetHash(strSource, ref strHashbyteSignature))//获取hash
            {
                //获取hash成功             
                SignHelper.SignatureFormatter(xmlPrivateKey, strHashbyteSignature, ref strEncryptedSignatureData);
            }
            else
            {
                //获取hash失败
                return;
            }

            #endregion

            #region 测试验签
            var strDeformatterData = strEncryptedSignatureData;//待验签的
            if(SignHelper.SignatureDeformatter(xmlPublicKey,strHashbyteSignature, strDeformatterData))
            {
                //验签成功
            }
            else
            {
                //验签失败
            }


            #endregion


        }
    }
}
