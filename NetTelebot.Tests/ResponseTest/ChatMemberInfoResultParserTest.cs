﻿using System;
using NetTelebot.BotEnum;
using NetTelebot.Result;
using NetTelebot.Tests.TypeTestObject;
using NetTelebot.Tests.TypeTestObject.ResultTestObject;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace NetTelebot.Tests.ResponseTest
{
    [TestFixture]
    internal static class ChatMemberInfoResultParserTest
    {
        /// <summary>
        /// Test for <see cref="FileInfoResult"/> parse field.
        /// </summary>
        [Test]
        public static void UserInfoResultTest()
        {
            const int id = 1000;
            const string firstName = "TestName";
            const string lastName = "testLastName";
            const string username = "testUsername";
            const string languageCode = "testLanguageCode";
            JObject userObject = UserInfoObject.GetObject(id, firstName, lastName, username, languageCode);

            const string status = "creator";

            JObject chatMember = ChatMemberInfoObject.GetObject(userObject, status, 0, true, true,
                true, true, true, true, true, true, true, true, true, true, true);


            dynamic fileInfoResultObject = ChatMemberInfoResultObject.GetObject(true, new JArray(chatMember));

            ChatMemberInfoResult chatMemberInfoResult = new ChatMemberInfoResult(fileInfoResultObject.ToString());

            Assert.Multiple(() =>
            {
                Assert.True(chatMemberInfoResult.Ok);
                Assert.AreEqual(firstName, chatMemberInfoResult.Result[0].User.FirstName);
                Assert.AreEqual(lastName, chatMemberInfoResult.Result[0].User.LastName);
                Assert.AreEqual(username, chatMemberInfoResult.Result[0].User.UserName);
                Assert.AreEqual(languageCode, chatMemberInfoResult.Result[0].User.LanguageCode);
                Assert.AreEqual(Status.creator, chatMemberInfoResult.Result[0].Status);
                Assert.AreEqual(0, chatMemberInfoResult.Result[0].UntilDateUnix);
                Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 0).ToLocalTime(),
                    chatMemberInfoResult.Result[0].UntilDate);
                Assert.True(chatMemberInfoResult.Result[0].CanBeEdited);
                Assert.True(chatMemberInfoResult.Result[0].CanChangeInfo);
                Assert.True(chatMemberInfoResult.Result[0].СanPostMessages);
                Assert.True(chatMemberInfoResult.Result[0].CanEditMessages);
                Assert.True(chatMemberInfoResult.Result[0].CanDeleteMessages);
                Assert.True(chatMemberInfoResult.Result[0].CanInviteUsers);
                Assert.True(chatMemberInfoResult.Result[0].CanRestrictMembers);
                Assert.True(chatMemberInfoResult.Result[0].CanPinMessages);
                Assert.True(chatMemberInfoResult.Result[0].CanPromoteMembers);
                Assert.True(chatMemberInfoResult.Result[0].CanSendMessages);
                Assert.True(chatMemberInfoResult.Result[0].CanSendMediaMessages);
                Assert.True(chatMemberInfoResult.Result[0].CanSendOtherMessages);
                Assert.True(chatMemberInfoResult.Result[0].CanAddWebPagePreviews);
            });
        }
    }
}
