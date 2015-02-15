using AutoMapper;
using DaysAway.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DaysAway.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {


        }

        private List<CommitmentViewModel> m_Commitments;
        public List<CommitmentViewModel> Commitments
        {
            get
            {
                return m_Commitments;
            }
            set
            {
                m_Commitments = value;
                NotifyPropertyChanged();
            }
        }

        public async Task Bind()
        {
            var commitmentRepository = new CommitmentInMemoryRepository();
            this.Commitments = (await commitmentRepository.GetAll()).Select(x => Mapper.Map<CommitmentViewModel>(x)).ToList();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
