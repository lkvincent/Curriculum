using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    #region ExeclDataSource
    /// <summary>
    /// ExeclDataSource
    /// </summary>
    public class ExeclDataSource
    {
        public string FileName
        {
            get;
            set;
        }

        public string SelectSQL
        {
            get;
            set;
        }
    }
    #endregion

    #region ImportErrorType
    /// <summary>
    /// ImportErrorType
    /// </summary>
    public enum ImportErrorType
    {
        Exchanged = 0,
        Save = 1
    }
    #endregion

    #region ImportItemDetail
    /// <summary>
    /// ImportItemDetail
    /// </summary>
    public class ImportItemDetail
    {
        public ImportErrorType ErrorType
        {
            get;
            set;
        }

        public string Key
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }
    }
    #endregion

    #region ImportResult
    /// <summary>
    /// ImportResult
    /// </summary>
    public class ImportResult
    {
        public bool Sucess
        {
            get;
            set;
        }
        private IList<ImportItemDetail> _FailListItem;
        public IList<ImportItemDetail> FailListItem
        {
            get
            {
                if (_FailListItem == null)
                {
                    _FailListItem = new List<ImportItemDetail>();
                }
                return _FailListItem;
            }
            set
            {
                _FailListItem = value;
            }
        }

        public string Description
        {
            get;
            set;
        }
    }
    #endregion
}
