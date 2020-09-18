﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SQLBuilder.UnitTest
{
    [TestClass]
    public class UpdateTest
    {
        /// <summary>
        /// 修改1
        /// </summary>
        [TestMethod]
        public void Test_Update_01()
        {
            var builder = SqlBuilder.Update<UserInfo>(() => new
            {
                Name = "",
                Sex = 1,
                Email = "123456@qq.com"
            });
            Assert.AreEqual("UPDATE [Base_UserInfo] SET [Name] = @Parameter1,[Sex] = @Parameter2,[Email] = @Parameter3", builder.Sql);
            Assert.AreEqual(3, builder.Parameters.Count);
        }

        /// <summary>
        /// 修改2
        /// </summary>
        [TestMethod]
        public void Test_Update_02()
        {
            var builder = SqlBuilder.Update<UserInfo>(() => new UserInfo
            {
                Sex = 1,
                Email = "123456@qq.com"
            }).Where(u => u.Id == 1);
            Assert.AreEqual("UPDATE [Base_UserInfo] SET [Sex] = @Parameter1,[Email] = @Parameter2 WHERE [Id] = @Parameter3", builder.Sql);
            Assert.AreEqual(3, builder.Parameters.Count);
        }

        /// <summary>
        /// 修改3
        /// </summary>
        [TestMethod]
        public void Test_Update_03()
        {
            var userInfo = new UserInfo
            {
                Name = "张强",
                Sex = 2
            };
            var builder = SqlBuilder.Update<UserInfo>(() => userInfo).Where(u => u.Id == 1);
            Assert.AreEqual("UPDATE [Base_UserInfo] SET [Sex] = @Parameter1,[Name] = @Parameter2,[Email] = NULL WHERE [Id] = @Parameter3", builder.Sql);
            Assert.AreEqual(3, builder.Parameters.Count);
        }

        /// <summary>
        /// 修改4
        /// </summary>
        [TestMethod]
        public void Test_Update_04()
        {
            var builder = SqlBuilder.Update<UserInfo>(() => new
            {
                Sex = 1,
                Email = "123456@qq.com"
            }).Where(u => u.Id == 1);
            Assert.AreEqual("UPDATE [Base_UserInfo] SET [Sex] = @Parameter1,[Email] = @Parameter2 WHERE [Id] = @Parameter3", builder.Sql);
            Assert.AreEqual(3, builder.Parameters.Count);
        }

        /// <summary>
        /// 修改5
        /// </summary>
        [TestMethod]
        public void Test_Update_05()
        {
            var builder = SqlBuilder.Update<Class>(() => new
            {
                UserId = 1,
                Name = "123456@qq.com"
            }, DatabaseType.MySql).Where(u => u.CityId == 1);
            Assert.AreEqual("UPDATE `Base_Class` SET `Name` = ?Parameter1 WHERE `CityId` = ?Parameter2", builder.Sql);
            Assert.AreEqual(2, builder.Parameters.Count);
        }

        /// <summary>
        /// 修改6
        /// </summary>
        [TestMethod]
        public void Test_Update_06()
        {
            var builder = SqlBuilder.Update<Class>(() => new Class
            {
                UserId = 1,
                Name = "123456@qq.com"
            }, DatabaseType.MySql).Where(u => u.CityId == 1);
            Assert.AreEqual("UPDATE `Base_Class` SET `Name` = ?Parameter1 WHERE `CityId` = ?Parameter2", builder.Sql);
            Assert.AreEqual(2, builder.Parameters.Count);
        }

        /// <summary>
        /// 修改7
        /// </summary>
        [TestMethod]
        public void Test_Update_07()
        {
            var data = new
            {
                UserId = 1,
                Name = "123456@qq.com"
            };
            var builder = SqlBuilder.Update<Class>(() => data, DatabaseType.MySql)
                                    .Where(u => u.CityId == 1);
            Assert.AreEqual("UPDATE `Base_Class` SET `Name` = ?Parameter1 WHERE `CityId` = ?Parameter2", builder.Sql);
            Assert.AreEqual(2, builder.Parameters.Count);
        }

        /// <summary>
        /// 修改8
        /// </summary>
        [TestMethod]
        public void Test_Update_08()
        {
            var data = new UserInfo
            {
                Id = 2,
                Name = "张强"
            };
            var builder = SqlBuilder.Update<UserInfo>(() => data, DatabaseType.MySql).WithKey(data);
            Assert.AreEqual("UPDATE `Base_UserInfo` SET `Sex` = ?Parameter1,`Name` = ?Parameter2,`Email` = NULL WHERE `Id` = ?Parameter3", builder.Sql);
            Assert.AreEqual(3, builder.Parameters.Count);
        }

        /// <summary>
        /// 修改9
        /// </summary>
        [TestMethod]
        public void Test_Update_09()
        {
            var data = new UserInfo
            {
                Id = 2,
                Name = "张强"
            };
            var builder = SqlBuilder.Update<UserInfo>(() => data, DatabaseType.MySql, false).WithKey(2);
            Assert.AreEqual("UPDATE `Base_UserInfo` SET `Sex` = ?Parameter1,`Name` = ?Parameter2 WHERE `Id` = ?Parameter3", builder.Sql);
            Assert.AreEqual(3, builder.Parameters.Count);
        }
    }
}