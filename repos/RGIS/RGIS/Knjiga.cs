using System;

public class Knjiga {
	private int id;
	private string naziv;
	private string avotr;
	private Pregled pregled;
	private datetime datum;
	private string opis;
	private string kategorija;

	public bool SetPregled(ref string pregled) {
		throw new System.NotImplementedException("Not implemented");
	}
	public void DodajVkniznico() {
		throw new System.NotImplementedException("Not implemented");
	}

	private OsebnaKniznica osebnaKniznica;
	private SeznamKnjig seznamKnjig;

}
