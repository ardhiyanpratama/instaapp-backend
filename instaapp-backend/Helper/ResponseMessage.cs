using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace instaapp_backend.Helper
{
    public enum ErrorCode
    {
        CompanyNotRegistered = 100,
        CompanyNotActive = 101,
        UserNotValid = 102,
        LifetimeTimesout = 103,
        MaxSending = 104,
        SystemError = 105,
        OTPInvalid = 106,
        AgreementNotAvailable = 107,
    }

    public partial class ResponseMessage
    {
        public long ErrorCode { get; set; }
        public dynamic Header { get; set; }
        public string Detail { get; set; }
        public string Note { get; set; } = "";
        public object Data { get; set; } = "";
    }

    public static class ResponseMessageExtensions
    {
        public static readonly string DEFAULT_HEADER_ERROR = "Gagal";
        public static readonly string DEFAULT_HEADER_SUCCESS = "Sukses";

        public static readonly string DEFAULT_MESSAGE_ERROR = "Hubungi Administrator";
#nullable enable
        public static class Database
        {
            public static readonly string DATA_NOT_FOUND = "Data Tidak Ditemukan";
            public static readonly string DATA_NOT_VALID = "Pastikan Data Sudah Lengkap Dan Benar";
            public static readonly string DATA_ALREADY_EXIST = "Data Duplikat";
            public static readonly string DELETE_SUCCESS = "Data Berhasil Dihapus";
            public static readonly string DELETE_FAILURE = "Data Gagal Dihapus";
            public static readonly string UPDATE_FAILURE = "Data Gagal Diubah";
            public static readonly string UPDATE_SUCCESS = "Data Berhasil Diubah";
            public static readonly string WRITE_SUCCESS = "Data Berhasil Ditambah";
            public static readonly string WRITE_FAILED = "Data Gagal Ditambah";
            public static readonly string SAVE_SUCCESS = "Data Berhasil Disimpan";
            public static readonly string PROC_SUCCESS = "Berhasil Menjalankan Prosedur";
            public static readonly string DBERROR_LOG = "Tidak Ada Error di Logs";
        }

        public static class File
        {
            public static readonly string DEFAULT_ERROR = "File Error";
            public static readonly string NOT_FOUND = "File Tidak Ditemukan";
            public static readonly string UPLOAD_SUCCESS = "Berhasil Upload File";
            public static readonly string UPLOAD_FAILED = "Gagal Upload File";
            public static readonly string EXTENSIONS_NOT_ALLOWED = "File Tidak Diperbolehkan Untuk Di Upload";
            public static readonly string SIZE_OVER_LIMIT = "Ukuran File Melebihi Maksimal Yang Di Perbolehkan";
            public static readonly string SIGNATURE_INVALID = "File Error";
            public static readonly string SIZE_NOT_VALID = "File Tidak Bisa Diproses";
            public static readonly string CREATION_ERROR = "Tidak Dapat Menyimpan File";
            public static readonly string THUMB_CREATION_ERROR = "Tidak Dapat Membuat Thumbnail";
            public static readonly string DELETE_SUCCESS = "Berhasil Menghapus File";
            public static readonly string DELETE_FAILED = "Gagal Menghapus File";
        }

        public static readonly string PROHIBITED_EDIT_DEFAULT = "Tidak Bisa Edit Kode DONE dan DEFAULT";
        public static readonly string AGENT_CANT_SAME = "Tipe Agen Tidak Boleh Sama";
        public static readonly string USERNAME_ALREADY_EXIST = "Username Sudah Dipakai";
        public static readonly string USER_INACTIVE = "User Tidak Ada/Tidak Aktif";
        public static readonly string USERNAME_EMPTY = "Username tidak boleh kosong";
        public static readonly string PASSWORD_EMPTY = "Password tidak boleh kosong";
        public static readonly string WRONG_PASSWORD = "Kata Sandi Salah";
        public static readonly string EMAIL_NOT_FOUND = "Email tidak ditemukan";
        public static readonly string CHECK_YOUR_EMAIL = "Silakan cek email Anda";
        public static readonly string EXPIRED_CHECK_PASSWORD = "Tautan kadaluarsa, silakan lupa password ulang";
        public static readonly string PASSWORD_HAS_CHANGED = "Kata sandi telah berhasil diubah";
        public static readonly string VOUCHER_SUCCESS = "Voucher berhasil dibuat";
        public static readonly string VOUCHER_CODE_NOTFOUND = "Kode voucher tidak ditemukan/tidak berlaku";
        public static readonly string DIFFERENT_LABEL_AMOUNT = "Jumlah Label Tidak Sama Dengan Jumlah Barang";
        public static readonly string PAYMENT_CANT_EMPTY = "Pembayaran Tidak Boleh Kosong";
        public static readonly string RECEIPT_NUMBER_ERROR = "Nomor Resi Tidak Terbentuk Silahkan Coba Lagi";
        public static readonly string LABEL_NOT_FOUND = "Label Tidak Ditemukan";
        public static readonly string STICKER_NOT_FOUND = "Sticker Tidak Ditemukan";
        public static readonly string NOT_ENOUGH_STICKER = "Jumlah Sticker Kurang";
        public static readonly string PRICE_NOT_FOUND = "Parent Harga Tidak Ditemukan";
        public static readonly string SCHEDULE_NOT_FOUND = "Data Asal Jadwal Tidak Ditemukan";
        public static readonly string AGENT_EXIST = "Agen Sudah Terdaftar Sebelumnya";
        public static readonly string SCHEDULE_CODE_CANT_SAME = "Kode Jadwal tidak boleh sama untuk tanggal yang sama";
        public static readonly string DIFFERENT_SCHEDULE_ID = "Id Jadwal Berbeda";
        public static readonly string PENDING_RECEIPT = "Resi Masuk Ke Dalam List Pending";
        public static readonly string PACKET_RECEIVED = "Paket Sudah Diserah Terima";
        public static readonly string PACKET_FAILED = "Tidak Dapat Melakukan Penerimaan";
        public static readonly string UPLOAD_FAILED = "Upload Gagal ";
        public static readonly string UPLOAD_SUCCESS = "Upload Berhasil ";
        public static readonly string RESTRICT_DELETE_FILE = "Anda Tidak Dapat Menghapus File Ini";
        public static readonly string WEIGHT_ZERO = "Selain Perusahaan, Berat Tidak Boleh 0";
        public static readonly string INSURANCE_SAME = "Asuransi Harus Sama";
        public static readonly string DIFFERENT_GRAND_TOTAL = "Grand Total Tidak Sama";
        public static readonly string DELIVERY_FAILED = "Ada Pengiriman Yang Belum Bisa Diterima";
        public static readonly string RECEIPT_SCANNED = "Resi Sudah Discan";
        public static readonly string SCHEDULE_CLOSED = "Jadwal Sudah Ditutup";
        public static readonly string LABEL_NUMBERING_CREATED = "Nomor Label Berhasil Dibuat";
        public static readonly string UNAUTHORIZED = "Unauthorized";
        public static readonly string ASSIGN_COURIER_SUCCESS = "Assign Kurir Berhasil";

        public static readonly string SUCCESS_HEADER = "Sukses!";
        public static readonly string FAIL_HEADER = "Gagal!";
        public static readonly string DEFAULT_DETAIL_MESSAGE = "Hubungi Administrator";
        public static readonly string HAS_NO_ACCESS = "Anda Tidak Mempunyai Akses";
        public static readonly string SYSTEM_ERROR = "System Error";

        public static readonly string MAX_SENDING_OTP = "Sudah 5 kali pengiriman , hanya bisa dilakukan next day / hari berikutnya";
        public static readonly string COMPANY_NOT_ACTIVE = "Company tidak aktif/tidak terdaftar";
        public static readonly string PHONE_INVALID = "No. Handphone Tidak Valid";
        public static readonly string MESSAGE_SEND = "OTP Terkirim Silahkan Cek Pesan Anda";
        public static readonly string MESSAGE_NOTSEND = "Terjadi Kesalahan Dalam Mengirim OTP, Silahkan Mencoba Kembali";
        public static readonly string INVALID_OTP = "Kode OTP Invalid";
        public static readonly string RTO_OTP = "Kode OTP Timesout, Silahkan Request Ulang Untuk Mendapatkan Kode OTP Baru";
        public static readonly string VALID_OTP = "OTP Valid";
        public static readonly string OTP_LENGTH_INVALID = "Panjang kode untuk OTP tidak sesuai";
        public static readonly string AGREEMENT_NOT_AVAILABLE = "Tidak terdapat layanan";

        private static class ContentType
        {
            public static readonly string ApplicationJson = "application/json";
        }

        public static ObjectResult InternalServerError(this ControllerBase controller, string? message = null)
        {
            return controller.StatusCode(StatusCodes.Status500InternalServerError, new ResponseMessage
            {
                Header = FAIL_HEADER,
                Detail = message ?? DEFAULT_DETAIL_MESSAGE
            });
        }
        public static OkObjectResult OkResponse(this ControllerBase controller, string message, string? note = null, object? data = null)
        {
            return controller.Ok(new ResponseMessage
            {
                Header = SUCCESS_HEADER,
                Detail = message,
                Note = note ?? null,
                Data = data ?? null
            });
        }
        public static NotFoundObjectResult NotFoundResponse(this ControllerBase controller, string? message = null, string? note = null)
        {
            return controller.NotFound(new ResponseMessage
            {
                Header = FAIL_HEADER,
                Detail = message ?? Database.DATA_NOT_FOUND,
                Note = note ?? string.Empty
            });
        }
        public static BadRequestObjectResult BadRequestResponse(this ControllerBase controller, string? message = null, string? note = null, long? errorcode = null)
        {
            return controller.BadRequest(new ResponseMessage
            {
                ErrorCode = errorcode ?? 400,
                Header = FAIL_HEADER,
                Detail = message ?? DEFAULT_DETAIL_MESSAGE,
                Note = note ?? string.Empty
            });
        }
        public static BadRequestObjectResult BadRequestResponse(this ControllerBase controller, Exception ex)
        {
            return controller.BadRequest(new ResponseMessage
            {
                Header = FAIL_HEADER,
                Detail = DEFAULT_DETAIL_MESSAGE,
                Note = ex.Message
            });
        }
        public static Task TimeoutExceptionResponse(this HttpResponse response, TimeoutException ex)
        {
            return response.ServiceUnavailableResponse(ex.Message);
        }
        public static Task UnathourizedAccessExceptionResponse(this HttpResponse response, UnauthorizedAccessException ex)
        {
            return response.UnathourizedResponse(ex.Message);
        }
        public static Task SystemExceptionResponse(this HttpResponse response, Exception ex)
        {
            return response.InternalErrorResponse(ex.Message);
        }
        public static Task ArgumenExceptionResponse(this HttpResponse response, Exception ex)
        {
            return response.BadRequestResponse(ex.Message);
        }
        public static Task BadHttpRequestResponse(this HttpResponse response, Exception ex)
        {
            return response.BadRequestResponse(ex.Message);
        }

        public static Task BadRequestResponse(this HttpResponse response, string message)
        {
            response.ContentType = ContentType.ApplicationJson;
            response.StatusCode = StatusCodes.Status400BadRequest;
            var responseMessage = new ResponseMessage
            {
                Header = FAIL_HEADER,
                Detail = message
            };

            return Task.Run(() =>
            {
                response.WriteAsync(JsonSerializer.Serialize(responseMessage));
            });
        }
        public static Task InternalErrorResponse(this HttpResponse response, string message)
        {
            response.ContentType = ContentType.ApplicationJson;
            response.StatusCode = StatusCodes.Status500InternalServerError;
            var responseMessage = new ResponseMessage
            {
                Header = FAIL_HEADER,
                Detail = DEFAULT_DETAIL_MESSAGE,
                Note = message
            };

            return Task.Run(() =>
            {
                response.WriteAsync(JsonSerializer.Serialize(responseMessage));
            });
        }
        public static Task UnathourizedResponse(this HttpResponse response, string message)
        {
            response.ContentType = ContentType.ApplicationJson;
            response.StatusCode = StatusCodes.Status401Unauthorized;
            var responseMessage = new ResponseMessage
            {
                Header = FAIL_HEADER,
                Detail = HAS_NO_ACCESS,
                Note = message
            };

            return Task.Run(() =>
            {
                response.WriteAsync(JsonSerializer.Serialize(responseMessage));
            });
        }
        public static Task ServiceUnavailableResponse(this HttpResponse response, string message)
        {
            response.ContentType = ContentType.ApplicationJson;
            response.StatusCode = StatusCodes.Status503ServiceUnavailable;
            var responseMessage = new ResponseMessage
            {
                Header = FAIL_HEADER,
                Detail = message
            };

            return Task.Run(() =>
            {
                response.WriteAsync(JsonSerializer.Serialize(responseMessage));
            });
        }
    }
}
