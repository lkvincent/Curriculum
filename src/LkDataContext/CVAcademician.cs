namespace LkDataContext
{
    partial class CVAcademicianDataContext
    {
        public CVAcademicianDataContext() :
            base(global::LkDataContext.AppConfig.ConnectString, mappingSource)
        {
            OnCreated();
        }
    }
}
