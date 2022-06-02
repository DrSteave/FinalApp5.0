namespace FinalApp5._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = GetFullInfo();
            DisplayInfoUser(result);
        }
        /// <summary>
        /// Метод собирает данные о кортеже
        /// </summary>
        /// <returns></returns>
        static (string firstName, string lastName, int age, string[] arrayPet, string[] colors) GetFullInfo()
        {
            (string firstName, string lastName, int age, string[] arrayPet, string[] colors) User;
            Console.Write("Введите свое имя: ");
            User.firstName = Console.ReadLine();

            Console.Write("Введите фамилию: ");
            User.lastName = Console.ReadLine();

            string age;
            int correctAge;
            bool isCorrectNumber;
            Console.Write("Введите ваш возраст: ");
            do
            {

                age = Console.ReadLine();
                isCorrectNumber = CheckNum(age, out correctAge);

                if (!isCorrectNumber)
                {
                    Console.Write("Пожалуйства введите корректный возраст: ");
                }
            }
            while (!isCorrectNumber);

            User.age = correctAge;

            bool isHavePet = false;
            Console.Write("У вас есть питомец. Нажмите Y если есть, N - если нет: ");
            string answer;

            do
            {
                answer = Console.ReadLine().ToLower();
                switch (answer)
                {
                    case "y":
                        isHavePet = true;
                        break;
                    case "n":
                        isHavePet = false;
                        break;

                    default:
                        Console.Write("Пожалуйста напишите Y или N: ");
                        continue;
                }
            }
            while (!(answer == "y" || answer == "n"));

            User.arrayPet = null;
            if (isHavePet)
            {
                Console.Write("Какое количество питомцем у вас: ");
                bool isCorrectPets;
                int countPets;
                do
                {
                    isCorrectPets = CheckNum(Console.ReadLine(), out countPets);
                }
                while (!isCorrectPets);

                User.arrayPet = CreateArrayPet(countPets);
            }

            int countColor;
            bool isCorrectColor;
            User.colors = null;

            Console.Write("Введите количество любимых цветов: ");
            do
            {

                isCorrectColor = CheckNum(Console.ReadLine(), out countColor);
                if (!isCorrectColor)
                {
                    Console.Write("Пожалуйста введите количество цветов корректно: ");
                }
            }
            while (!isCorrectColor);
            User.colors = CreateArrayColors(countColor);

            var test = User;
            return User;
        }

        /// <summary>
        /// Выводит на экран данные кортежа
        /// </summary>
        /// <param name="user"></param>
        static void DisplayInfoUser((string firstName, string lastName, int age, string[] arrayPet, string[] colors) user)
        {
            Console.WriteLine("\n==================================================\n");
            Console.WriteLine("Имя: " + user.firstName);
            Console.WriteLine("Фамилия: " + user.lastName);
            Console.WriteLine("Возраст: " + user.age);
            if (user.arrayPet != null)
            {
                Console.WriteLine("Питомцы: " + string.Join(", ", user.arrayPet));
            }
            else
            {

            }

            if (user.colors != null)
            {
                Console.WriteLine("Цвета: " + string.Join(", ", user.colors));
            }
        }

        /// <summary>
        /// Создает массив цветов
        /// </summary>
        /// <param name="num">количество</param>
        /// <returns></returns>
        static string[] CreateArrayColors(int num)
        {
            string[] colors = new string[num];
            int count = 1;
            for (int i = 0; i < colors.Length; i++)
            {
                Console.Write($"Введите цвет под номером {count++}: ");
                colors[i] = Console.ReadLine();
            }

            return colors;
        }

        /// <summary>
        /// Создает массив кличек собак
        /// </summary>
        /// <param name="num">количество</param>
        /// <returns></returns>
        static string[] CreateArrayPet(int num)
        {
            string[] pets = new string[num];
            int count = 1;
            for (int i = 0; i < pets.Length; i++)
            {
                Console.Write($"Введите кличку питомца под номером {count++}: ");
                pets[i] = Console.ReadLine();
            }

            return pets;
        }

        static bool CheckNum(string number, out int corrNumber)
        {
            if (int.TryParse(number, out int convertNumber))
            {
                if (convertNumber <= 0)
                {
                    corrNumber = convertNumber;
                    return false;
                }
                else
                {
                    corrNumber = convertNumber;
                    return true;
                }
            }
            else
            {
                corrNumber = 0;
                return false;
            }
        }
    }
}