using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.PartFactory
{
    public class PartMP8855:PartCommon
    {
        public PartMP8855(string partnumber):base(partnumber)
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    try
                    {

                        if (CanLsbMonitor)
                        {
                            lock (lockFocus)
                            {
                                if (CanLsbMonitor)
                                {
                                    if (ControlGroupItems == null)
                                        continue;
                                    foreach (var item in ControlGroupItems)
                                    {

                                        foreach (var reg in item.Registers)
                                        {
                                            foreach (var bt in reg.BitControls)
                                            {
                                                if (bt.BitName.Contains("VOUT_MAX") || bt.BitName.Contains("VOUT_MARGIN_HIGH") ||
                                             bt.BitName.Contains("VOUT_MARGIN_LOW") || bt.BitName.Contains("VOUT_COMMAND")
                                             )
                                                {
                                                    var temp = bt.CurrentBitValue;
                                                    bt.GetLSB = GetLsb;
                                                    bt.CurrentBitValue = temp;

                                                }
                                            }


                                        }
                                    }
                                    System.Threading.Thread.Sleep(300);
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            });
        }

        public double GetLsb(string name)
        {
            foreach (var item in ControlGroupItems)
            {
                foreach (var reg in item.Registers)
                {
                    bool flg = name.Contains("READ_VOUT");


                    foreach (var bit in reg.BitControls)
                    {
                        if (bit.BitName.Contains("Voltage Feedback Divider Range"))
                        {


                            if (bit.CurrentBitValue != null)
                            {

                                if (bit.CurrentBitValue.Contains("000"))
                                {
                                    if (flg)
                                    {
                                        return 0.003;
                                    }
                                    else
                                        return 0.0015;
                                }

                                if (bit.CurrentBitValue.Contains("001"))
                                {
                                    if (flg)
                                    {
                                        return 0.003 * 2;
                                    }
                                    else
                                        return 0.003;

                                }

                                if (bit.CurrentBitValue.Contains("010"))
                                {
                                    if (flg)
                                    {
                                        return 0.003 * 4;
                                    }
                                    else
                                        return 0.006;

                                }


                                if (bit.CurrentBitValue.Contains("011"))
                                {
                                    if (flg)
                                    {
                                        return 0.003 * 8;
                                    }
                                    else
                                        return 0.012;

                                }

                                if (bit.CurrentBitValue.Contains("100"))
                                {
                                    if (flg)
                                    {
                                        return 0.003 * 16;
                                    }
                                    else
                                        return 0.024;

                                }


                            }

                        }
                    }

                }
            }
            return 0;
        }
    }
}
