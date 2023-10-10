using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    internal class Message
    {
        public string Title { get; set; }

        private string _text = "";
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                if (value.Equals(""))
                {
                    //Console.WriteLine("Message can't be blank");
                    throw new ArgumentException("Message can't be blank");
                } else
                {
                    _text = value;
                }
            }
        }

        /*
        public String getMessage()
        {
            return this.text;
        }

        public void setMessage(string text)
        {
            this.text = text;
        }
        */
        public Message(string title, string text)
        {
            Title = title;
            Text = text;
        }

        public void ShowMessage()
        {
            Console.WriteLine(Title);
            Console.WriteLine(Text);
        }
    }
}
