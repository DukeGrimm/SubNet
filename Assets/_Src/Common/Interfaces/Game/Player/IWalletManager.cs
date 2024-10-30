namespace SubNet.Common.Interfaces.Game.Player
{
    public interface IWalletManager
    {
        void DepositFunds(float amount);
        float GetPrimaryBalance();
        void WithdrawFunds(float amount);
    }
}
