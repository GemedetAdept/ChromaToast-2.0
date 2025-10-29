using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChromaToast.Exceptions;

namespace ChromaToast {
	internal class Palette {
		public List<Card> Cards {get; set;}
		public int Count {get; set;}

		public Palette() {
			Cards = new List<Card>();
			Count = Cards.Count;
		}

		public void AppendCard(Card card) {
			Cards.Add(card);
			Count++;
		}

		public void OverwriteCard(Card card, int index) {
			Cards[index] = card;
		}

		public void AppendPalette(Palette palette) {
			Cards.AddRange(palette.Cards);	
		}
	}
}
