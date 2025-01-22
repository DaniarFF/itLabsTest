using System.Text.RegularExpressions;

namespace itLabs.Client;

public class InputValidation
{
  /// <summary>
  ///   Проверяет корректность введённого ФИО.
  ///   ФИО должно состоять из трёх слов, разделённых пробелами, каждое из которых начинается с заглавной буквы.
  /// </summary>
  /// <param name="fullName">ФИО для проверки.</param>
  /// <returns>True, если ФИО корректно.</returns>
  public bool ValidateFullName(string fullName)
  {
    if (string.IsNullOrWhiteSpace(fullName))
      return false;

    var pattern = @"^[А-ЯЁ][а-яё]+ [А-ЯЁ][а-яё]+ [А-ЯЁ][а-яё]+$";
    return Regex.IsMatch(fullName, pattern);
  }

  /// <summary>
  ///   Проверяет корректность номера телефона.
  ///   Номер должен соответствовать формату: +79999999999.
  /// </summary>
  /// <param name="phoneNumber">Номер телефона для проверки.</param>
  /// <returns>True, если номер корректен.</returns>
  public bool ValidatePhoneNumber(string phoneNumber)
  {
    if (string.IsNullOrWhiteSpace(phoneNumber))
      return false;

    var pattern = @"^\+7\d{3}\d{3}\d{2}\d{2}$";
    return Regex.IsMatch(phoneNumber, pattern);
  }

  /// <summary>
  ///   Проверяет корректность адреса электронной почты.
  /// </summary>
  /// <param name="email">Email для проверки.</param>
  /// <returns>True, если email корректен; иначе False.</returns>
  public bool ValidateEmail(string email)
  {
    if (string.IsNullOrWhiteSpace(email))
      return false;

    var pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
    return Regex.IsMatch(email, pattern);
  }
}