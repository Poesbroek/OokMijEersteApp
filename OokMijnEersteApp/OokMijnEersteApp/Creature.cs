using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OokMijnEersteApp
{
    public class Creature : INotifyPropertyChanged
    {
     public float hunger { get; set;}
        [JsonIgnore]
        public string hungerState => hunger switch
        {
            >= 0.9f => "FullLoveBar.png",
            > 0.7f => "FourLoveBar.png",
            > 0.5f => "ThreeLoveBar.png",
            > 0.3f => "TwoLoveBar.png",
            > 0f => "OneLoveBar.png",
            <= 0f => "EmptyLoveBar.png",
            _ => throw new Exception("WTF MAN????")
        };

        public float thirst { get; set;}
        [JsonIgnore]
        public string thirstState => thirst switch
        {
            >= 0.9f => "FullLoveBar.png",
            > 0.7f => "FourLoveBar.png",
            > 0.5f => "ThreeLoveBar.png",
            > 0.3f => "TwoLoveBar.png",
            > 0f => "OneLoveBar.png",
            <= 0f => "EmptyLoveBar.png",
            _ => throw new Exception("WTF MAN????")
        };
     public float boredom { get; set;}

        public string boredomState => boredom switch
        {
            >= 0.9f => "FullLoveBar.png",
            > 0.7f => "FourLoveBar.png",
            > 0.5f => "ThreeLoveBar.png",
            > 0.3f => "TwoLoveBar.png",
            > 0f => "OneLoveBar.png",
            <= 0f => "EmptyLoveBar.png",
            _ => throw new Exception("WTF MAN????")
        };
        public float tired { get; set;}
        public string tiredState => tired switch
        {
            >= 0.9f => "FullLoveBar.png",
            > 0.7f => "FourLoveBar.png",
            > 0.5f => "ThreeLoveBar.png",
            > 0.3f => "TwoLoveBar.png",
            > 0f => "OneLoveBar.png",
            <= 0f => "EmptyLoveBar.png",
            _ => throw new Exception("WTF MAN????")
        };
     public float loneliness { get; set;}
        public string lonelinessState => loneliness switch
        {
            >= 0.9f => "FullLoveBar.png",
            > 0.7f => "FourLoveBar.png",
            > 0.5f => "ThreeLoveBar.png",
            > 0.3f => "TwoLoveBar.png",
            > 0f => "OneLoveBar.png",
            <= 0f => "EmptyLoveBar.png",
            _ => throw new Exception("WTF MAN????")
        };
        public float stimulated { get; set;}
        public string stimulatedState => stimulated switch
        {
            >= 0.9f => "FullLoveBar.png",
            > 0.7f => "FourLoveBar.png",
            > 0.5f => "ThreeLoveBar.png",
            > 0.3f => "TwoLoveBar.png",
            > 0f => "OneLoveBar.png",
            <= 0f => "EmptyLoveBar.png",
            _ => throw new Exception("WTF MAN????")
        };
        public int id { get; set; }
     public string   userName { get; set; }
        public string name { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

    }

}
