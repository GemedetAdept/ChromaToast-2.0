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

		public void OverwriteCards(List<Card> cards, int[] indices) {
			
			// Array length mismatch
			bool lengthsMatch = false;
			try {
				if (cards.Count != indices.Length) {
					throw new ArrayLengthMismatchException();
				}
				else { lengthsMatch = true; }
			}
			catch (ArrayLengthMismatchException ex) {
				Console.WriteLine(ex.Message + " Array lengths: {0}, {1}.",
					cards.Count, indices.Length	
				);
			}

			// Largest index mismatch
			bool largestIndexMatches = false;
			int largestIndex = Int32.MinValue;
			try {
				for (int i=0; i < indices.Length; i++) {
					if (indices[i] > largestIndex) { largestIndex = indices[i]; }	
				}

				if (this.Cards.Count < largestIndex) {
					throw new LargestIndexMismatchException();
				}
				else { largestIndexMatches = true; }
			}

			catch (LargestIndexMismatchException ex) {
				Console.WriteLine(ex.Message + "Target array length: {0}. Largest index input: {1}",
					this.Cards.Count, largestIndex	
				);
			}

			if (lengthsMatch==true && largestIndexMatches==true) {
				int indicesIter = 0;
				for (int i=0; i < this.Cards.Count; i++) {
					if (indices[indicesIter] == i) { this.Cards[i] = cards[indicesIter]; }	

					indicesIter++;
				}
			}
		}
	}
}
