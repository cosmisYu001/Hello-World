using System;
using System.Security.Cryptography.X509Certificates;
namespace MyGame
{
    class ProMM
    {
        public string ID { get; set; }
        public int ATK { get; set; }
        public int HD { get; set; }

        public string Name { get; set; }
        public int ATK2 { get; set; }
        public int HD2 { get; set; }


        public static void Main(string[] args)
        {
            Pro P = new Pro();

            P.ID = "猎人";

            P.ATK = 30;

            P.HP = 300;


            Pro X = new Pro();

            X.ID = "猎物";

            X.HP = 200;

            X.ATK = 70;




            for (int i = 1; i <= 20; i++)
            {
                Console.WriteLine("第" + i + "回合");

                P.回血(100);

                P.Hit(X);

                if (X.HP <= 0)
                {
                    Console.WriteLine(X.ID + "已被击败"!);

                    break;
                }

                X.回血2(30);

                X.Hit(P);

                if (P.HP <= 0)
                {
                    Console.WriteLine(P.ID + "已死亡"!);

                    break;
                }



                Console.WriteLine("----战斗结束---");

            }

        }
        public void AtkMod()
        {
            Console.WriteLine("攻击动作已执行");
        }

        public static void 回血()
        {
            Console.WriteLine("回血动作已执行");
        }

        public static void 回血2()
        {
            Console.WriteLine("回血动作已执行");
        }


    }
    class Pro
    {
        public string ID { get; set; }

        public int ATK { get; set; }

        public int HP { get; set; }

        public event Action OnAtk;

        public event Action On回血;

        public event Action OFF回血;
        public void Hit(Pro 目标)
        {
            OnAtk?.Invoke();

            int SH = ATK;

            Random R = new Random();

            int 暴击伤害判定 = R.Next(1, 10);

            if (暴击伤害判定 <= 7)
            {
                SH = ATK * 2;

                Console.WriteLine("暴击了！伤害翻倍！");
            }

            目标.HP = 目标.HP - SH;

            if (目标.HP <= 0) 目标.HP = 0;

            Console.WriteLine(ID + "打了" + 目标.ID + SH + "点伤害");

            Console.WriteLine(目标.ID + "还剩" + 目标.HP + "HP");
        }

        public void 回血(int VL)
        {
            On回血?.Invoke();

            HP = HP + VL;

            if (HP > 300) HP = 300;

            Console.WriteLine(ID + "回血了" + VL + "点，当前血量：" + HP);
        }

        public void 回血2(int LV)
        {
            OFF回血?.Invoke();

            HP = HP + LV;

            if (HP > 200) HP = 200;

            Console.WriteLine(ID + "回血了" + LV + "点当前血量：" + HP);
        }
    }

}
