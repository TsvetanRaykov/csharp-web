﻿using SIS.MvcFramework.Attributes.Validation;

namespace MyMusaca.Web.BindingModels
{
    public class UserLoginBindingModel
    {
        [RequiredSis]
        public string Username { get; set; }
        [RequiredSis]
        public string Password { get; set; }
    }
}