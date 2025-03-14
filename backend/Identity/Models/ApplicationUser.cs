﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public int? Age { get; set; }    
        public string? Gender { get; set; }
        public int? Weight { get; set; }
        public int? Height { get; set; }
        public string? Bio {  get; set; }   


        public byte[] SecretKey { get; private set; }

        public string? PhotoUrl { get; set; }
        public string? PhotoPublicId { get; set; }

        public ApplicationUser()
        {
            SecretKey = GenerateSecretKey(32);
        }

        private byte[] GenerateSecretKey(int keySize)
        {
            var key = new byte[keySize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
            }
            return key;
        }
    }
}
