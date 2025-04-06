using ToroTrader.Application.Domain.Entities.Base;

namespace ToroTrader.Application.Domain.Entities
{
    public class Product : Entity
    {
        public Product(string bondAsset, string index, decimal tax, string issuerName, decimal unitPrice, int stock)
        {
            BondAsset = bondAsset ?? throw new ArgumentNullException(nameof(BondAsset));
            Index = index ?? throw new ArgumentNullException(nameof(Index));
            Tax = tax;
            IssuerName = issuerName ?? throw new ArgumentNullException(nameof(IssuerName));
            UnitPrice = unitPrice;
            Stock = stock;
        }

        public string BondAsset { get; private set; }                     // Tipo do Produto de Renda Fixa (ex: CDB)
        public string Index { get; private set; }                         // Indexador (ex: IPCA, Selic)
        public decimal Tax { get; private set; }                          // Taxa atrelada ao Indexador
        public string IssuerName { get; private set; }                    // Emissor do Produto
        public decimal UnitPrice { get; private set; }                    // Preço unitário do Produto
        public int Stock { get; private set; }                            // Estoque do produto
    }
}
