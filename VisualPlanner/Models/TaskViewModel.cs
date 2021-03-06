﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VisualPlanner.Models
{
    public enum TypesView
    {
        Project,
        Organizer
    }
    public class TaskViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public TypesView TypeView { get; set; }
        public int TaskId { get; set; }
        public TaskModel Task { get; set; }

    }
}