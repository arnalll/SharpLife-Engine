﻿/***
*
*	Copyright (c) 1996-2001, Valve LLC. All rights reserved.
*	
*	This product contains software technology licensed from Id 
*	Software, Inc. ("Id Technology").  Id Technology (c) 1996 Id Software, Inc. 
*	All Rights Reserved.
*
*   This source code contains proprietary and confidential information of
*   Valve LLC and its suppliers.  Access to this code is restricted to
*   persons who have executed a written SDK license with Valve.  Any access,
*   use or distribution of this code by or to any unlicensed person is illegal.
*
****/

using System.Collections.Generic;
using System.Numerics;

namespace SharpLife.Models.MDL.FileFormat
{
    public class BodyMesh
    {
        public class NormalInfo
        {
            public int Bone;
            public Vector3 Normal;
        }

        public List<short> TriangleCommands { get; set; }

        public List<NormalInfo> Normals { get; set; }

        public int Skin { get; set; }
    }
}