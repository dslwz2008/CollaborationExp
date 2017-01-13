using UnityEngine;
using System.Collections;

public static class PartipatorSessionData  {
    private static int s_gameTime;
    private static int s_playerHealth;

    public static int GameTime
    {
        get
        {
            return s_gameTime;
        }
    }

    public static int PlayerHealth 
    {
        get
        {
            return s_playerHealth;
        }
    }

    public static void Restart()
    { 
        
    }
}
