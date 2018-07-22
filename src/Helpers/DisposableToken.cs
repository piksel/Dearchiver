using System;
using System.Windows.Forms;

namespace Piksel.Dearchiver.Helpers
{
    public static class DisposableToken
    {
        internal static DisposableToken<TContent> FromContent<TContent>(TContent content, Action<TContent, bool> disposeFunc)
        {
            return new DisposableToken<TContent>(content, disposeFunc);
        }
    }

    public class DisposableToken<TContent>: IDisposable
    {
        private TContent content;
        private readonly Action<TContent, bool> disposeFunc;
        private bool disposed = false;

        public TContent Content => content;

        public DisposableToken(TContent content, Action<TContent, bool> disposeFunc)
        {
            this.content = content;
            this.disposeFunc = disposeFunc;
        }

        public static implicit operator TContent(DisposableToken<TContent> token)
            => token.Content;

        #region IDisposable Support

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                disposeFunc(content, disposing);
                disposed = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~DisposableToken() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}