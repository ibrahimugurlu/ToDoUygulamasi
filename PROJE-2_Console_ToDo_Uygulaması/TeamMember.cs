using System;
using System.Collections.Generic;
using System.Text;

namespace PROJE_2_Console_ToDo_Uygulaması
{
    public class TeamMember
    {
        Color _title;
        String _content;
        string _member;
        Size _size;
        
        public Color Title { get => _title; set => _title = value; }
        public string Content { get => _content; set => _content = value; }
        public string Member { get => _member; set => _member = value; }
        public Size Size { get => _size; set => _size = value; }
       

        public TeamMember(Color title, String content, string member, Size size)
        {
            this.Title = title;
            this.Content = content;
            this.Member = member;
            this.Size = size;
           
        }




    }
}
