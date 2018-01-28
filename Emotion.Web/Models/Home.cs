using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emotion.Web.Models
{
    public class Home
    {
        public int Id { get; set; }
        public String WelcomeMessage { get; set; }
        public String FooterMessage { get; set; } = "Footer By @Ed M";

    }
}