using System;
using System.Collections.Generic;
using System.Text;

namespace Probe.Modelo
{
    public class Consumo
    {
        public int IdConsumoLocal { get; set; }
        public int IdConsumo { get; set; }
        public decimal Mineral15w40 { get; set; }
        public decimal Mineral20w50 { get; set; }
        public decimal SemiSintetico15w40 { get; set; }
        public decimal SemiSintetico20w50 { get; set; }
        public decimal DexronIII { get; set; }
        public decimal Motos4t { get; set; }
        public decimal ISO80w90 { get; set; }
        public decimal Diesel50 { get; set; }
        public decimal Diesel15w40 { get; set; }
        public decimal Hidraulico68 { get; set; }
        public decimal LigaFrenoDot3 { get; set; }
        public decimal Flushing { get; set; }
    }
}
