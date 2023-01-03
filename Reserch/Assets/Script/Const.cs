using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Const
{
    public static class CO
    {
        public const float COMMAND_WAIT_TIME = 0.35f;//１つのコマンド時間
        public const int MAX_COMMAND_LIST_SIZE = 9;//コマンドの最高

        public const int maxCost=40;

        public static class MAP_SIZE
        {
            public const int X = 8;
            public const int Y = 4;
        }

        public static class FLOOR_DISTANCE
        {
            public const float X = 1.3f;
            public const float Y = 0.76f;
        }

        public static class PATH
        {
            public const string IMAGES = "";
            public const string PREFAB = "";

            public const string COMMAND = "CommandDate/";
            public const string COMMAND_ENEMY = "CommandDate/Enemy/";
            public const string COMMAND_PLAYER = "CommandDate/Player/";
            public const string COMMAND_BACKBORNE = "CommandDate/BackBorne/";
        }
    }
}

