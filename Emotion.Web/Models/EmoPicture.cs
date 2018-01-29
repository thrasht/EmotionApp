using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Emotion.Web.Models
{
    public class EmoPicture
    {
        public int Id { get; set; }
        public String Name { get; set; }

        [Required]
        [MaxLength(200)]
        public String Path { get; set; }

        public virtual ObservableCollection<EmoFace> Faces { get; set; }

    }
}