using LeDucTai_206.Data;
using LeDucTai_206.Models;
using LeDucTai_206.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LeDucTai_206
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		csdl_thuephongContext context= new csdl_thuephongContext();
		private void show()
		{
			dgPhong.ItemsSource = context.Phongs.ToList();
		}
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			cbMaLoai.ItemsSource= context.Loaiphongs.ToList();
			show();
		}

		private void Xoa_Click(object sender, RoutedEventArgs e)
		{
			if (dgPhong.SelectedItem != null)
			{
				if (dgPhong.SelectedItem != null)
				{
					string phongId = (dgPhong.SelectedItem as Phong).Maphong;

					MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn xóa phòng này?", "Xác nhận xóa", MessageBoxButton.OKCancel, MessageBoxImage.Question);

					if (result == MessageBoxResult.OK)
					{
						var chitietRecords = context.Chitietphieuthues.Where(c => c.Maphong == phongId).ToList();

						if (chitietRecords.Count > 0)
						{
							context.Chitietphieuthues.RemoveRange(chitietRecords);
						}

						Phong phong = context.Phongs.Find(phongId);
						if (phong == null)
						{
							MessageBox.Show("Không tìm thấy.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
						}
						else
						{
							context.Phongs.Remove(phong);
							context.SaveChanges();
							show();
						}
					}
				}
				else
				{
					MessageBox.Show("Vui lòng chọn 1 dòng để xóa.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
				}
			}
		}
		private void dgPhong_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (dgPhong.SelectedValue != null)
			{
				string id = dgPhong.SelectedValue.ToString();
				Phong phong = context.Phongs.Find(id);
				//gridHangHoa.DataContext = HangHoaVM.transferHanghoaVM(hh);
			}
		}


		private void lenhThem_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;	
		}

		private void lenhThem_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			NhapPhongThueVM vm = gridNhapPhongThue.DataContext as NhapPhongThueVM;

			if (vm != null)
			{
				Loaiphong selectedLoai = cbMaLoai.SelectedItem as Loaiphong;

				if (selectedLoai != null)
				{
					Phong phong = new Phong
					{
						Maphong = vm.Maphong,
						Tinhtrang = int.Parse(vm.Tinhtrang),
						Maloai = selectedLoai.Maloai,
					};

					try
					{
						context.Phongs.Add(phong);
						context.SaveChanges();
						show();
					}
					catch (Exception ex)
					{
						MessageBox.Show($"Error saving to database: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
				else
				{
					MessageBox.Show("SelectedLoai is null", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBox.Show("VM is null", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}
