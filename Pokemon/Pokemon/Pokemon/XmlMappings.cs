/* 
    Licensed under the Apache License, Version 2.0
    
    http://www.apache.org/licenses/LICENSE-2.0
    */
using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Pokemon
{
	[XmlRoot(ElementName="Player")]
	public class Player {
		[XmlElement(ElementName="Id")]
		public int Id { get; set; }
		[XmlElement(ElementName="Name")]
		public string Name { get; set; }
		[XmlElement(ElementName="Username")]
		public string Username { get; set; }
        [XmlElement(ElementName = "City")]
        public string City { get; set; }
        [XmlElement(ElementName="Paid")]
		public Boolean Paid { get; set; }
	}

	[XmlRoot(ElementName="PlayerTable")]
	public class PlayerTable {
		[XmlElement(ElementName="Player")]
		public List<Player> Players { get; set; }
	}

	[XmlRoot(ElementName="Pokemon")]
	public class Pokemon {
		[XmlElement(ElementName="Id")]
		public int Id { get; set; }
		[XmlElement(ElementName="Name")]
		public string Name { get; set; }
		[XmlElement(ElementName="Attack")]
		public int Attack { get; set; }
		[XmlElement(ElementName="Defense")]
		public int Defense { get; set; }
	}

	[XmlRoot(ElementName="PokemonTable")]
	public class PokemonTable {
		[XmlElement(ElementName="Pokemon")]
		public List<Pokemon> Pokemon { get; set; }
	}

	[XmlRoot(ElementName="Ownership")]
	public class Ownership {
		[XmlElement(ElementName="PlayerId")]
		public int PlayerId { get; set; }
		[XmlElement(ElementName="PokemonId")]
		public int PokemonId { get; set; }
		[XmlElement(ElementName="Level")]
		public int Level { get; set; }
		[XmlElement(ElementName="NumberOwned")]
		public int NumberOwned { get; set; }
	}

	[XmlRoot(ElementName="OwnershipTable")]
	public class OwnershipTable {
		[XmlElement(ElementName="Ownership")]
		public List<Ownership> Ownership { get; set; }
	}

	[XmlRoot(ElementName="PokemonDB")]
	public class PokemonDB {
		[XmlElement(ElementName="PlayerTable")]
		public PlayerTable PlayerTable { get; set; }
		[XmlElement(ElementName="PokemonTable")]
		public PokemonTable PokemonTable { get; set; }
		[XmlElement(ElementName="OwnershipTable")]
		public OwnershipTable OwnershipTable { get; set; }
	}

}
