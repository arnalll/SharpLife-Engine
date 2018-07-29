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

using System;

namespace SharpLife.CommandSystem.Commands
{
    [Flags]
    public enum CommandFlags
    {
        None = 0,

        /// <summary>
        /// Save variable value during shutdown
        /// </summary>
        Archive = 1 << 0,

        /// <summary>
        /// Don't log variable changes
        /// </summary>
        UnLogged = 1 << 1,

        /// <summary>
        /// Log variable changes using a user-defined string
        /// </summary>
        Protected = 1 << 2,
    }
}
