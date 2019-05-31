using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Models
{
    public class AccountCard
    {
        public AccountCard(Account account, List<TrackProgress> trackProgresses)
        {
            Id = account.Id;
            Car = account.Car;
            CarVariat = account.CarVariant;
            Empty = account.Empty;
            FaceId = account.FaceId;
            Name = account.Name;
            TrackProgress = trackProgresses;
        }

        public string Id;
        public bool Empty = true;
        public int FaceId;
        public string Name;
        public string Car;
        public int CarVariat;
        public List<TrackProgress> TrackProgress;
    }
}
