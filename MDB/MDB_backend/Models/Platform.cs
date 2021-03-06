﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDB_backend.Models
{
    public class Platform
    {
        public enum PlatformType 
        { 
            ThreeDS = 1,
            DC = 2,
            GBA = 3,
            GC = 4,
            N64 = 5,
            PC = 6,
            PS = 7,
            PS2 = 8,
            PS3 = 9,
            PS4 = 10,
            PSP = 11,
            Switch = 12,
            Vita = 13,
            Wii = 14,
            WiiU = 15,
            X360 = 16,
            Xbox = 17,
            Xone = 18
        }

        public int id { get; private set; }
        public PlatformType Type { get; private set; }

        [JsonConstructor]
        public Platform(int id, PlatformType type)
        {
            this.id = id;
            this.Type = type;
        }
    }
}
