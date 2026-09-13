using System;
using System.Collections.Generic;
using System.Text;

namespace EsRipassoRobot_Andreella
{
    internal class CRobot
    {
        private string modello;
        private float potenza;
        private int stato;
        private int anno;

        public string Modello
        {
            get { return modello; }
        }
        public float Potenza
        {
            get { return potenza; }
        }
        public int Stato
        {
            get { return stato; }
        }
        public int Anno
        {
            get { return anno; }
        }

        public CRobot(string modello, float potenza, int stato, int anno)
        {
            this.modello = modello;
            this.potenza = potenza;
            this.stato = stato;
            this.anno = anno;
        }

        public string Visualizza()
        {
            string statoDescrizione = stato > 0 ? "Operativo" : "Guasto";
            return $"Modello: {Modello}\tPotenza: {potenza}kW\tStato: {statoDescrizione}\tAnno: {anno}";
        }
    }

}
