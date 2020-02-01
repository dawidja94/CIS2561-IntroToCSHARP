 
using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace WFMovieDB
{
	[XmlRoot(ElementName="Movie")]
	public class Movie {
		[XmlElement(ElementName="Id")]
		public int Id { get; set; }
		[XmlElement(ElementName="Title")]
		public string Title { get; set; }
		[XmlElement(ElementName="Released")]
		public int Released { get; set; }
		[XmlElement(ElementName="Gross")]
		public int Gross { get; set; }
		[XmlElement(ElementName="Studio")]
		public int Studio { get; set; }
	}

	[XmlRoot(ElementName="MovieTable")]
	public class MovieTable {
		[XmlElement(ElementName="Movie")]
		public List<Movie> Movies { get; set; }
	}

	[XmlRoot(ElementName="Studio")]
	public class Studio {
		[XmlElement(ElementName="Id")]
		public int Id { get; set; }
		[XmlElement(ElementName="Name")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName="StudioTable")]
	public class StudioTable {
		[XmlElement(ElementName="Studio")]
		public List<Studio> Studios { get; set; }
	}

	[XmlRoot(ElementName="MovieDB")]
	public class MovieDB {
		[XmlElement(ElementName="MovieTable")]
		public MovieTable MovieTable { get; set; }
		[XmlElement(ElementName="StudioTable")]
		public StudioTable StudioTable { get; set; }
	}
}
