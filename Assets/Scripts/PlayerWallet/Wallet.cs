using System;

namespace Scripts.PlayerWallet
{
    public static class Wallet
    {
        public static float Gold = 0;

        public static bool Pay(float priceGold)
        {
            if(Gold >= priceGold)
            {
                Gold -= priceGold;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
