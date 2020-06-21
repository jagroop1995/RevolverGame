using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolverGame.Data
{
    public class RevolverCylinder
    {
        private int[] bulletChambers;

        public RevolverCylinder()
        {
            bulletChambers = new int[6];
        }

        public void LoadTheBullet(int pos)
        {
            if( pos >= 0 && pos < 6) {
                bulletChambers[pos] = 1;
            }
            
        }

        public void SpinChambers()
        {
            RotateChamber(new Random().Next(1, 13));
        }


        private void RotateChamber(int times)
        {
            for (int i = 1; i <= times; i++)
            {
                int temp = bulletChambers[5];
                for (int j = 5; j > 0; j--)
                {
                    bulletChambers[j] = bulletChambers[j - 1];
                }
                bulletChambers[0] = temp;
            }
        }

        public bool FireBullet(int pos)
        {
            return bulletChambers[pos] == 1;
        }
    }
}
