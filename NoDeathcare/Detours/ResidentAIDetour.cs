using System.Runtime.CompilerServices;
using ColossalFramework;
using NoDeathcare.Redirection.Attributes;

namespace NoDeathcare.Detours
{
    [TargetType(typeof(ResidentAI))]
    public class ResidentAIDetour : ResidentAI
    {
        [RedirectMethod]
        public override void SimulationStep(uint citizenID, ref Citizen data)
        {
            //begin mod
            if (!data.Dead)
            {
                if (this.UpdateAge(citizenID, ref data))
                {
                    return;
                }
                //Shit's impossible to reach because !data.Dead and data.Dead must be true
                /*if (data.Dead)
                {
                    Singleton<CitizenManager>.instance.ReleaseCitizen(citizenID);
                    return;
                }*/
            }
            //end mod
            if (!data.Dead)
                this.UpdateHome(citizenID, ref data);
            if (!data.Sick && !data.Dead)
            {
                if (this.UpdateHealth(citizenID, ref data))
                {           
                    return;
                }
                //begin mod
                //Shit's impossible to reach, same reason as before
                /*if (data.Dead)
                {
                    Singleton<CitizenManager>.instance.ReleaseCitizen(citizenID);
                }*/
                //end mod
                this.UpdateWellbeing(citizenID, ref data);
                this.UpdateWorkplace(citizenID, ref data);
            }
            this.UpdateLocation(citizenID, ref data);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [RedirectReverse]
        private void UpdateHome(uint citizenID, ref Citizen data)
        {
            return;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [RedirectReverse]
        private bool UpdateHealth(uint citizenID, ref Citizen data)
        {
            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [RedirectReverse]
        private bool UpdateAge(uint citizenID, ref Citizen data)
        {
            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [RedirectReverse]
        private void UpdateWellbeing(uint citizenID, ref Citizen data)
        {
            return;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [RedirectReverse]
        private void UpdateWorkplace(uint citizenID, ref Citizen data)
        {
            return;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [RedirectReverse]
        private void UpdateLocation(uint citizenID, ref Citizen data)
        {
            return;
        }
    }
}
