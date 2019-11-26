namespace Rangen.UseCases.UseCasesBaseClasses
{
    public interface IOutputPort<in TUseCaseResponse>
    {
        void Handle(TUseCaseResponse response);
    }
}
