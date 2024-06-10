namespace Helpers{
    public class PagingModel{
        public int currentPage{set;get;}
        public int countPages{set;get;}
        public Func<int?, string> generateURl{set;get;}
    }
}