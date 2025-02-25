using System.Diagnostics;

internal class Problem
{
	public static void Main(string[] args)
	{
		double[] GDPThailanPercent = new double[7] { 2.4, 2.8, 3.0, 3.2, 3.6, 3.4, 4.0 };
		double[] GDPVietnamPercent = new double[7] { 6.9, 6.8, 6.7, 6.6, 6.5, 6.4, 6.8 };

		double[] GDPVietnam = new double[7];
		double[] GDPThailan = new double[7];
		string[] DifferentGDP = new string[7];

		// init data table
		for (int i = 0; i < 7; i++)
		{
			if (i == 0)
			{
				GDPVietnam[i] = 429.72 * (1 + GDPVietnamPercent[i] / 100);
				GDPThailan[i] = 514.93 * (1 + GDPThailanPercent[i] / 100);
			}
			else
			{
				GDPVietnam[i] = GDPVietnam[i - 1] * (1 + GDPVietnamPercent[i] / 100);
				GDPThailan[i] = GDPThailan[i - 1] * (1 + GDPThailanPercent[i] / 100);
			}

			double tempDifferent = 1 - (GDPVietnam[i] / GDPThailan[i]);
			tempDifferent = Math.Round(tempDifferent, 3);
			DifferentGDP[i] = (tempDifferent < 0) ? ("" + Math.Abs(tempDifferent) * 100) : ("-" + tempDifferent * 100);
			DifferentGDP[i] += "%";

			GDPVietnam[i] = Math.Round(GDPVietnam[i], 2);
			GDPThailan[i] = Math.Round(GDPThailan[i], 2);
		}

		// Print table GDP
		Console.WriteLine("GDP of Thailand and Vietnam in each year from 2024 to 2030 :");
		Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10} ",
				  "Year", "Thaland", "Vietnam", "Different %");

		for (int i = 0; i < 7; i++)
		{
			string s = string.Format("{0,-10} {1,-10} {2,-10} {3,-10} ",
				(2024 + i) + "", GDPThailan[i], GDPVietnam[i], DifferentGDP[i]);
			Console.WriteLine(s);
		}

		// surpasses GDP year
		for (int i = 0; i < 7; i++)
		{
			if (GDPVietnam[i] > GDPThailan[i])
			{
				Console.WriteLine("The year when Vietnam's GDP surpasses Thailan's GDP is :" + (2024 + i));
				break;
			}
		}
	}
}