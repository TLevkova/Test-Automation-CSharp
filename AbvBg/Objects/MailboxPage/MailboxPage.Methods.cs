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

        public void SendMessage(string receiver, string subject)
        {
            TypeInto(ReceiverField, receiver);
            TypeInto(SubjectField, subject);
            SendMessageButton.Click();
        }
    }
}
