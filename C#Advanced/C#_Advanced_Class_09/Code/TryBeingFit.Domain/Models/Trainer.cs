using TryBeingFit.Domain.Enums;
using TryBeingFit.Domain.Iterfaces;

namespace TryBeingFit.Domain.Models
{
    public class Trainer : User, ITrainer
    {
        public int YearsOfExperience { get; set; }
        public Trainer()
        {
            Role = UserRoleEnum.Trainer; // our trainer will always have the role trainer
        }
        public override string GetInfo()
        {
            return $"{FirstName} {LastName} - {YearsOfExperience} years of experience";
        }

        public void Reschedule(LiveTraining liveTraining, int days)
        {
            //validation
            if(liveTraining == null)
            {
                throw new NullReferenceException("Live training cannot be null");
                //throw new ArgumentNullException(nameof(liveTraining), "Live training cannot be null");  // ???
            }
            // validation whether it is the same  trainer! another trainer can not reschedule some ele's training
            if(Id != liveTraining.Trainer.Id)
            {
                throw new Exception("You cannot reschedule this training, you re not the trainer");
            }
            liveTraining.NextSession = liveTraining.NextSession.AddDays(days);
        }
    }
}
