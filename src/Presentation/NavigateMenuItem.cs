using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Enum;

namespace Presentation
{
public enum NavigateItemType
    {
        Normal = 0,
        Front = 1,
        MessageBox = 2,
        RecruitFlow = 3
    }

    public class NavigateMenuItem
    {
        public const string NotPermissionPage = "../CanNotAccess.aspx";
        public const string CurrentUserName = "$$CurrentUserName$$";

        public class NavigateMenuIco
        {
            public string IcoUrl
            {
                get;
                set;
            }

            public string ToolTip
            {
                get;
                set;
            }
        }

        public string Text
        {
            get;
            set;
        }

        public string HelpTip
        {
            get;
            set;
        }

        public int DisplayOrder
        {
            get;
            set;
        }

        public string LinkUrl
        {
            get;
            set;
        }

        public NavigateItemType NavigateType { get; set; }

        public NavigateMenuIco Image
        {
            get;
            set;
        }

        public IList<NavigateMenuItem> NavigateMenuItemList
        {
            get;
            set;
        }

        public static IList<NavigateMenuItem> LoadNavigateMenuItemList(UserType userType, bool isPermission)
        {

            switch (userType)
            {
                case UserType.DepartAdmin:
                    return LoadDepartAdminNavigateItems();
                case UserType.Admin:
                    break;
                case UserType.Enterprise:
                    return LoadEnterpriseNavigateItems(isPermission);
                case UserType.Student:
                    break;
                case UserType.Teacher:
                    return LoadTeacherNavigateItems();
                case UserType.Family:
                    return LoadFamilyNavigateItems();
                case UserType.Supper:
                    return LoadSupperNavigateItems();
            }
            return LoadStudentNavigateItems();
        }

        private static IList<NavigateMenuItem> LoadStudentNavigateItems()
        {
            IList<NavigateMenuItem> menuList = new List<NavigateMenuItem>();

            #region 基本信息
            var group = new NavigateMenuItem
            {
                Text = "基本信息",
                HelpTip = "基本信息",
                LinkUrl = "UserInfo.aspx",
                DisplayOrder = 0
            };
            menuList.Add(group);
            #endregion

            #region 个人介绍
            group = new NavigateMenuItem
            {
                Text = "个人介绍",
                HelpTip = "个人介绍",
                LinkUrl = "UserIntroduce.aspx",
                DisplayOrder = 1
            };
            menuList.Add(group);
            #endregion

            #region 个人博文管理
            group = new NavigateMenuItem
            {
                Text = "博文管理",
                HelpTip = "博文管理",
                LinkUrl = "StudenyDailyEssayList.aspx",
                DisplayOrder = 2,
                NavigateMenuItemList = new List<NavigateMenuItem>()
            };
            menuList.Add(group);
            #endregion

            #region 个人相册
            //group = new NavigateMenuItem
            //{
            //    Text = "个人相册",
            //    HelpTip = "个人相册",
            //    LinkUrl = "StudentDictoryManage.aspx",
            //    DisplayOrder = 2,
            //    NavigateMenuItemList = new List<NavigateMenuItem>()
            //};
            //menuList.Add(group);
            #endregion

            #region 成绩列表
            group = new NavigateMenuItem
            {
                Text = "成绩列表",
                HelpTip = "成绩列表",
                LinkUrl = "StudentScoreList.aspx",
                DisplayOrder = 3,
                NavigateMenuItemList = new List<NavigateMenuItem>()
            };
            menuList.Add(group);
            #endregion

            #region 项目经历列表
            group = new NavigateMenuItem
            {
                Text = "项目管理",
                HelpTip = "项目管理",
                LinkUrl = "StudentProjectList.aspx",
                DisplayOrder = 4,
                NavigateMenuItemList = new List<NavigateMenuItem>()
            };
            menuList.Add(group);
            #endregion

            #region 课外活动列表
            group = new NavigateMenuItem
            {
                Text = "活动管理",
                HelpTip = "活动管理",
                LinkUrl = "StudentActivityList.aspx",
                DisplayOrder = 5,
                NavigateMenuItemList = new List<NavigateMenuItem>()
            };
            menuList.Add(group);
            #endregion

            #region 技能列表
            group = new NavigateMenuItem
            {
                Text = "技能管理",
                HelpTip = "技能管理",
                LinkUrl = "StudentProfessionalList.aspx",
                DisplayOrder = 6,
                NavigateMenuItemList = new List<NavigateMenuItem>()
            };
            menuList.Add(group);
            #endregion

            #region 技能列表
            group = new NavigateMenuItem
            {
                Text = "实习管理",
                HelpTip = "实习管理",
                LinkUrl = "StudentExercitationList.aspx",
                DisplayOrder = 6,
                NavigateMenuItemList = new List<NavigateMenuItem>()
            };
            menuList.Add(group);
            #endregion

            #region 密码管理
            group = new NavigateMenuItem
            {
                Text = "密码管理",
                HelpTip = "密码管理",
                LinkUrl = "ChangePassowrd.aspx",
                DisplayOrder = 7,
                NavigateMenuItemList = new List<NavigateMenuItem>()
            };
            menuList.Add(group);
            #endregion

            #region 简历生成
            group = new NavigateMenuItem
            {
                Text = "简历生成",
                HelpTip = "简历生成",
                LinkUrl = "../../../../Template/StudentResume.aspx?StudentNum=" + CurrentUserName,
                DisplayOrder = 8,
                NavigateMenuItemList = new List<NavigateMenuItem>()
            };
            menuList.Add(group);
            #endregion

            #region 个人主页

            group = new NavigateMenuItem
                {
                    Text = "个人主页",
                    HelpTip = "个人主页",
                    DisplayOrder = 9,
                    NavigateMenuItemList = new List<NavigateMenuItem>(),
                    NavigateType = NavigateItemType.Front
                };
            menuList.Add(group);
            #endregion

            #region 家庭设置
            //group = new NavigateMenuItem
            //    {
            //        Text = "家庭设置",
            //        HelpTip = "家庭设置",
            //        DisplayOrder = 10,
            //        NavigateMenuItemList = new List<NavigateMenuItem>(),
            //        LinkUrl = "StudentFamilySetted.aspx",
            //        NavigateType = NavigateItemType.Normal
            //    };
            //menuList.Add(group);
            #endregion

            #region 企业岗位列表
            group = new NavigateMenuItem
            {
                Text = "企业岗位列表",
                HelpTip = "企业岗位列表",
                DisplayOrder = 11,
                NavigateMenuItemList = new List<NavigateMenuItem>(),
                LinkUrl = "EnterpriseJobList.aspx",
                NavigateType = NavigateItemType.Normal
            };
            menuList.Add(group);
            #endregion

            #region 导师推荐列表
            group = new NavigateMenuItem
            {
                Text = "导师推荐列表",
                HelpTip = "导师推荐列表",
                DisplayOrder = 12,
                NavigateMenuItemList = new List<NavigateMenuItem>(),
                LinkUrl = "TeacherReferralsList.aspx",
                NavigateType = NavigateItemType.Normal
            };
            menuList.Add(group);
            #endregion

            #region 应聘管理
            group = new NavigateMenuItem
            {
                Text = "应聘管理",
                HelpTip = "应聘管理",
                DisplayOrder = 13,
                NavigateMenuItemList = new List<NavigateMenuItem>(),
                LinkUrl = "JobRequestList.aspx",
                NavigateType = NavigateItemType.Normal
            };
            menuList.Add(group);
            #endregion

            #region 站内信件
            group = new NavigateMenuItem
            {
                Text = "站内信件({0})",
                HelpTip = "站内信件",
                LinkUrl = "../MessageBox/MessageBoxList.aspx",
                DisplayOrder =14,
                NavigateType = NavigateItemType.MessageBox
            };
            menuList.Add(group);
            #endregion

            return menuList;
        }

        private static IList<NavigateMenuItem> LoadTeacherNavigateItems()
        {
            IList<NavigateMenuItem> menuList = new List<NavigateMenuItem>();
            #region 基本信息
            var group = new NavigateMenuItem
            {
                Text = "基本信息",
                HelpTip = "基本信息",
                LinkUrl = "UserInfo.aspx",
                DisplayOrder = 0
            };
            menuList.Add(group);
            #endregion

            #region 活动发布列表
            group = new NavigateMenuItem
            {
                Text = "活动发布列表",
                HelpTip = "活动发布列表",
                LinkUrl = "PublishActivityList.aspx",
                DisplayOrder = 1,
                NavigateMenuItemList = new List<NavigateMenuItem>()
            };
            menuList.Add(group);
            #endregion

            #region 项目审批列表
            group = new NavigateMenuItem
            {
                Text = "项目审批列表",
                HelpTip = "项目审批列表",
                LinkUrl = "StudentProjectVerifyList.aspx",
                DisplayOrder = 2,
                NavigateMenuItemList = new List<NavigateMenuItem>()
            };
            menuList.Add(group);
            #endregion

            #region 活动审批列表
            group = new NavigateMenuItem
            {
                Text = "活动审批列表",
                HelpTip = "活动审批列表",
                LinkUrl = "StudentActivityVerifyList.aspx",
                DisplayOrder = 3,
                NavigateMenuItemList = new List<NavigateMenuItem>()
            };
            menuList.Add(group);
            #endregion

            #region 实习审批列表
            group = new NavigateMenuItem
            {
                Text = "实习审批列表",
                HelpTip = "实习审批列表",
                LinkUrl = "StudentExercitationVerifyList.aspx",
                DisplayOrder = 4,
                NavigateMenuItemList = new List<NavigateMenuItem>()
            };
            menuList.Add(group);
            #endregion

            #region 邀请推荐列表
            group = new NavigateMenuItem
            {
                Text = "邀请推荐列表",
                HelpTip = "邀请推荐列表",
                LinkUrl = "AskedReferralsToEnterpriseList.aspx",
                DisplayOrder = 5,
                NavigateMenuItemList = new List<NavigateMenuItem>()
            };
            menuList.Add(group);
            #endregion

            #region 企业岗位列表
            group = new NavigateMenuItem
            {
                Text = "企业岗位列表",
                HelpTip = "企业岗位列表",
                LinkUrl = "EnterpriseJobList.aspx",
                DisplayOrder = 6,
                NavigateMenuItemList = new List<NavigateMenuItem>()
            };
            menuList.Add(group);
            #endregion

            #region 站内信件
            group = new NavigateMenuItem
            {
                Text = "站内信件({0})",
                HelpTip = "站内信件",
                LinkUrl = "../MessageBox/MessageBoxList.aspx",
                DisplayOrder = 7,
                NavigateType = NavigateItemType.MessageBox
            };
            menuList.Add(group);
            #endregion

            #region 密码管理
            group = new NavigateMenuItem
            {
                Text = "密码管理",
                HelpTip = "密码管理",
                LinkUrl = "ChangePassowrd.aspx",
                DisplayOrder = 8,
                NavigateMenuItemList = new List<NavigateMenuItem>()
            };
            menuList.Add(group);
            #endregion

            return menuList;
        }

        private static IList<NavigateMenuItem> LoadEnterpriseNavigateItems(bool isPermission)
        {
            IList<NavigateMenuItem> menuList = new List<NavigateMenuItem>();
            #region 基本信息
            var group = new NavigateMenuItem
            {
                Text = "基本信息",
                HelpTip = "基本信息",
                LinkUrl = "UserInfo.aspx",
                DisplayOrder = 0
            };
            menuList.Add(group);
            #endregion

            #region 职位信息列表
            group = new NavigateMenuItem
            {
                Text = "职位信息列表",
                HelpTip = "职位信息列表",
                LinkUrl = !isPermission ? NavigateMenuItem.NotPermissionPage : "EnterpriseJobList.aspx",
                DisplayOrder = 1
            };
            menuList.Add(group);

            #endregion

            #region 申请职位列表
            group = new NavigateMenuItem
            {
                Text = "申请职位列表",
                HelpTip = "申请职位列表",
                LinkUrl = !isPermission ? NavigateMenuItem.NotPermissionPage : "JobRequesterList.aspx",
                DisplayOrder = 2
            };
            menuList.Add(group);

            #endregion

            #region 教师推荐列表

            group = new NavigateMenuItem
                {
                    Text = "教师推荐列表",
                    HelpTip = "教师推荐列表",
                    LinkUrl =
                        !isPermission ? NavigateMenuItem.NotPermissionPage : "JobRequesterList.aspx?IsReferralsQueueIDNotNull=true",
                    DisplayOrder = 2
                };
            menuList.Add(group);

            #endregion

            #region 应聘批次管理
            group = new NavigateMenuItem
            {
                Text = "应聘批次管理",
                HelpTip = "应聘批次管理",
                LinkUrl = !isPermission ? NavigateMenuItem.NotPermissionPage : "EnterpriseRecruitBatchList.aspx",
                DisplayOrder = 3,
                NavigateType = NavigateItemType.Normal
            };
            menuList.Add(group);
            #endregion

            #region 应聘流程
            group = new NavigateMenuItem
            {
                Text = "应聘流程管理",
                HelpTip = "应聘流程管理",
                LinkUrl = !isPermission ? NavigateMenuItem.NotPermissionPage : "RecruitFlowList.aspx",
                DisplayOrder = 4,
                NavigateType = NavigateItemType.Normal
            };
            menuList.Add(group);
            #endregion

            #region 邮件模板
            group = new NavigateMenuItem
            {
                Text = "站内信模板",
                HelpTip = "站内信模板",
                LinkUrl = !isPermission ? NavigateMenuItem.NotPermissionPage : "EmailTemplateList.aspx",
                DisplayOrder = 5,
                NavigateType = NavigateItemType.Normal
            };
            menuList.Add(group);
            #endregion

            #region 站内信件
            group = new NavigateMenuItem
            {
                Text = "站内信件({0})",
                HelpTip = "站内信件",
                LinkUrl = "../MessageBox/MessageBoxList.aspx",
                DisplayOrder = 6,
                NavigateType = NavigateItemType.MessageBox
            };
            menuList.Add(group);
            #endregion

            #region 密码管理
            group = new NavigateMenuItem
            {
                Text = "密码管理",
                HelpTip = "密码管理",
                LinkUrl = "ChangePassowrd.aspx",
                DisplayOrder = 7,
                NavigateMenuItemList = new List<NavigateMenuItem>()
            };
            menuList.Add(group);
            #endregion

            return menuList;
        }

        private static IList<NavigateMenuItem> LoadDepartAdminNavigateItems()
        {
            IList<NavigateMenuItem> menuList = new List<NavigateMenuItem>();
            var group = new NavigateMenuItem
                {
                    Text = "学生家长管理",
                    HelpTip = "学生家长管理",
                    LinkUrl = "StudentFamilyList.aspx",
                    DisplayOrder = 0,
                    NavigateMenuItemList = new List<NavigateMenuItem>()
                };
            menuList.Add(group);
            group = new NavigateMenuItem
                {
                    Text = "学生信息导入",
                    HelpTip = "学生信息导入",
                    LinkUrl = "ImportStudent.aspx",
                    DisplayOrder = 1,
                    NavigateMenuItemList = new List<NavigateMenuItem>()
                };
            menuList.Add(group);

            group = new NavigateMenuItem
                {
                    Text = "职能组管理",
                    HelpTip = "职能组管理",
                    LinkUrl = "TeacherGroupManage.aspx",
                    DisplayOrder = 2,
                    NavigateMenuItemList = new List<NavigateMenuItem>()
                };
            menuList.Add(group);

            group = new NavigateMenuItem
                {
                    Text = "教师管理",
                    HelpTip = "教师管理",
                    LinkUrl = "TeacherManager.aspx",
                    DisplayOrder = 3,
                    NavigateMenuItemList = new List<NavigateMenuItem>()
                };
            menuList.Add(group);

            group = new NavigateMenuItem
                {
                    Text = "企业管理",
                    HelpTip = "企业管理",
                    LinkUrl = "EnterpriseManage.aspx",
                    DisplayOrder = 4,
                    NavigateMenuItemList = new List<NavigateMenuItem>()
                };
            menuList.Add(group);

            group = new NavigateMenuItem
                {
                    Text = "新闻管理",
                    HelpTip = "新闻管理",
                    LinkUrl = "MessageManage.aspx",
                    DisplayOrder = 5,
                    NavigateMenuItemList = new List<NavigateMenuItem>()
                };
            menuList.Add(group);

            #region 招聘流程管理

            group = new NavigateMenuItem
                {
                    Text = "招聘流程管理",
                    HelpTip = "招聘流程管理",
                    LinkUrl = "RecruitFlowList.aspx",
                    DisplayOrder = 6,
                    NavigateType = NavigateItemType.Normal
                };
            menuList.Add(group);

            #endregion

            #region 站内信件

            group = new NavigateMenuItem
                {
                    Text = "站内信件({0})",
                    HelpTip = "站内信件",
                    LinkUrl = "../MessageBox/MessageBoxList.aspx",
                    DisplayOrder = 7,
                    NavigateType = NavigateItemType.MessageBox
                };
            menuList.Add(group);

            #endregion

            group = new NavigateMenuItem
                {
                    Text = "密码管理",
                    HelpTip = "密码管理",
                    LinkUrl = "ChangePassword.aspx",
                    DisplayOrder = 8,
                    NavigateMenuItemList = new List<NavigateMenuItem>()
                };
            menuList.Add(group);

            return menuList;
        }

        private static IList<NavigateMenuItem> LoadFamilyNavigateItems()
        {
            IList<NavigateMenuItem> menuList = new List<NavigateMenuItem>();

            #region 基本信息

            var group = new NavigateMenuItem
                {
                    Text = "基本信息",
                    HelpTip = "基本信息",
                    LinkUrl = "UserInfo.aspx",
                    DisplayOrder = 0
                };
            menuList.Add(group);

            #endregion

            #region 子女简历

            group = new NavigateMenuItem
                {
                    Text = "子女简历",
                    HelpTip = "子女简历",
                    LinkUrl = "../../../../Template/StudentResume.aspx?StudentNum=" + CurrentUserName,
                    DisplayOrder = 1
                };
            menuList.Add(group);

            #endregion

            #region 子女主页

            group = new NavigateMenuItem
                {
                    Text = "子女主页",
                    HelpTip = "子女主页",
                    NavigateType = NavigateItemType.Front,
                    DisplayOrder = 3
                };
            menuList.Add(group);

            #endregion

            //#region 子女互动

            //group = new NavigateMenuItem
            //    {
            //        Text = "子女互动",
            //        HelpTip = "子女互动",
            //        LinkUrl = "../MsgBox/SyMsgBoxList.aspx",
            //        DisplayOrder = 4,
            //        NavigateType = NavigateItemType.Normal
            //    };
            //menuList.Add(group);
            //#endregion

            #region 子女博文列表

            group = new NavigateMenuItem
                {
                    Text = "子女博文列表",
                    HelpTip = "子女博文列表",
                    LinkUrl = "Children/ChildDailyEssayList.aspx",
                    DisplayOrder = 5,
                    NavigateType = NavigateItemType.Normal
                };
            menuList.Add(group);

            #endregion

            #region 子女成绩列表

            //group = new NavigateMenuItem
            //    {
            //        Text = "子女成绩列表",
            //        HelpTip = "子女成绩列表",
            //        LinkUrl = "Children/ChildCourseScoreList.aspx",
            //        DisplayOrder = 6
            //    };
            //menuList.Add(group);

            #endregion

            #region 子女项目列表

            group = new NavigateMenuItem
                {
                    Text = "子女项目列表",
                    HelpTip = "子女项目列表",
                    LinkUrl = "Children/ChildProjectList.aspx",
                    DisplayOrder = 7,
                    NavigateType = NavigateItemType.Normal
                };
            menuList.Add(group);

            #endregion

            #region 子女活动列表

            group = new NavigateMenuItem
                {
                    Text = "子女活动列表",
                    HelpTip = "子女活动列表",
                    LinkUrl = "Children/ChildActivityList.aspx",
                    DisplayOrder = 8,
                    NavigateType = NavigateItemType.Normal
                };
            menuList.Add(group);

            #endregion

            #region 子女实习列表

            group = new NavigateMenuItem
                {
                    Text = "子女实习列表",
                    HelpTip = "子女实习列表",
                    LinkUrl = "Children/ChildExercitationList.aspx",
                    DisplayOrder = 9,
                    NavigateType = NavigateItemType.Normal
                };
            menuList.Add(group);

            #endregion

            #region 子女技能列表

            group = new NavigateMenuItem
                {
                    Text = "子女技能列表",
                    HelpTip = "子女技能列表",
                    LinkUrl = "Children/ChildProfessionalList.aspx",
                    DisplayOrder = 10,
                    NavigateType = NavigateItemType.Normal
                };
            menuList.Add(group);

            #endregion

            #region 子女相关管理

            //group = new NavigateMenuItem
            //    {
            //        Text = "子女相关管理",
            //        HelpTip = "子女相关管理",
            //        LinkUrl = "Children/ChildRelativeManage.aspx",
            //        DisplayOrder = 11,
            //        NavigateType = NavigateItemType.Normal
            //    };
            //menuList.Add(group);

            #endregion

            #region 站内信件

            group = new NavigateMenuItem
                {
                    Text = "站内信件({0})",
                    HelpTip = "站内信件",
                    LinkUrl = "../MessageBox/MessageBoxList.aspx",
                    DisplayOrder = 12,
                    NavigateType = NavigateItemType.MessageBox
                };
            menuList.Add(group);

            #endregion

            #region 密码管理

            group = new NavigateMenuItem
                {
                    Text = "密码管理",
                    HelpTip = "密码管理",
                    LinkUrl = "ChangePassowrd.aspx",
                    DisplayOrder = 13
                };
            menuList.Add(group);

            #endregion

            return menuList;
        }

        private static IList<NavigateMenuItem> LoadSupperNavigateItems()
        {
            IList<NavigateMenuItem> menuList = new List<NavigateMenuItem>();

            #region 系统日志

            var group = new NavigateMenuItem
            {
                Text = "系统日志",
                HelpTip = "系统日志",
                LinkUrl = "SysLogList.aspx",
                DisplayOrder = 0
            };
            menuList.Add(group);

            #endregion

            #region 系统邮件

            group = new NavigateMenuItem
            {
                Text = "系统邮件",
                HelpTip = "系统邮件",
                LinkUrl = "MailQueueList.aspx",
                DisplayOrder = 1
            };
            menuList.Add(group);

            #endregion

            return menuList;
        }
    }
}
