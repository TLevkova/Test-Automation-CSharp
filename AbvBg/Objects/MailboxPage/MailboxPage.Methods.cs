using System.Linq;
using TechTalk.SpecFlow;

namespace AbvBg.Objects
{
    partial class MailboxPage
    {
        public void ClickOnNewMessageButton()
        {
            NewMessageButton.Click();
        }

        public void WriteNewMessage(string newMessage)
        {
            TextArea.SendKeys(newMessage);
        }

        public void SendMessageFromTable(Table messageInfo)
        {
            string receiver = messageInfo.Rows[0]["Receiver"];
            string subject = messageInfo.Rows[0]["Subject"];

            TypeInto(ReceiverField, receiver);
            TypeInto(SubjectField, subject);
            SendMessageButton.Click();
        }
    }
}
