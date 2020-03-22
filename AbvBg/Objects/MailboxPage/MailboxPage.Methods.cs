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

        public void SendMessage(Table messageData)
        {
            string receiver = messageData.Rows[0]["Receiver"];
            string subject = messageData.Rows[0]["Subject"];

            TypeInto(ReceiverField, receiver);
            TypeInto(SubjectField, subject);
            SendMessageButton.Click();
        }
    }
}
