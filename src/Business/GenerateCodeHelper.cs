using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LkDataContext;

namespace Business
{
    public static class GenerateCodeHelper
    {
        public enum GenerateCodeType
        {
            Depart = 0,
            Marjor = 1,
            Enterprise = 2,
            EnterpriseJob = 3,
            StudentFamily = 4
        }

        public static string GenerateCode(GenerateCodeType type, string referenceCode)
        {
            using (
                CVAcademicianDataContext dataContext =new CVAcademicianDataContext())
            {
                switch (type)
                {
                    case GenerateCodeType.Depart:
                        var departItem = dataContext.Departs.OrderByDescending(it => it.ID).FirstOrDefault();
                        var maxDepartCode = 0;
                        if (departItem != null)
                        {
                            maxDepartCode = int.Parse(departItem.Code);
                        }
                        maxDepartCode++;
                        return maxDepartCode.ToString().PadLeft(3, '0');
                    case GenerateCodeType.Enterprise:
                        var code = GetRnd(8);
                        while (dataContext.Enterprises.Any(it => it.Code == code))
                        {
                            code = GetRnd(8);
                        }
                        return code;
                    case GenerateCodeType.EnterpriseJob:
                        var jobItem =
                            dataContext.EnterpriseJobs.Where(it => it.EnterpriseCode == referenceCode)
                                       .OrderByDescending(it => it.CreateTime)
                                       .FirstOrDefault();
                        var maxJobCode = 0;
                        if (jobItem != null)
                        {
                            maxJobCode = int.Parse(jobItem.Code.Substring(8, 4));
                        }
                        maxJobCode++;
                        return referenceCode + maxJobCode.ToString().PadLeft(4, '0');
                    case GenerateCodeType.StudentFamily:
                        if (String.IsNullOrEmpty(referenceCode)) return null;
                        var maxStudentFamily =
                            dataContext.StudentFamilyAccounts.Where(it => it.StudentNum == referenceCode)
                                       .Max(it => it.UserName);
                        int index = 0;
                        if (maxStudentFamily != null)
                        {
                            index = int.Parse(maxStudentFamily.Substring(maxStudentFamily.Length - 5 - 1, 5));
                        }
                        return String.Format("{0}{1}", referenceCode,
                                             (index + 1).ToString().PadLeft(5, '0'));
                    default:
                        var marjorItem =
                            dataContext.Marjors.Where(it => it.DepartCode == referenceCode)
                                       .OrderByDescending(it => it.ID)
                                       .FirstOrDefault();
                        var maxMarjorCode = 0;
                        if (marjorItem != null)
                        {
                            maxMarjorCode = int.Parse(marjorItem.Code.Substring(3, 3));
                        }
                        maxMarjorCode++;
                        return referenceCode + maxMarjorCode.ToString().PadLeft(3, '0');
                }
            }
        }

        private static char[] _chars = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 
            'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q','R','S','T','U','V','W','X','Y','Z','a', 'b', 
            'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q','r','s',
            't','u','v','w','x','y','z','0','1','2','3','4','5','6','7','8','9'};
        private static Random r = new Random();
        public static string GetRnd(int width)
        {
            int max = _chars.Length - 1;
            string temp = "";

            for (int i = 0; i < width; i++)
            {
                char c = _chars[r.Next(0, max)];
                temp += c;
            }
            return temp;
        }
    }
}
