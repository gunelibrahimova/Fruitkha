﻿using Entities;

namespace Fruitkha.ViewModel
{
    public class ArticleVM
    {
        public New NewSingle { get; set; }
        public List<New> News { get; set; }
        public K205User User { get; set; }
        public List<Comment> Comments { get; set; }
        public Comment Comment { get; set; }
    }
}