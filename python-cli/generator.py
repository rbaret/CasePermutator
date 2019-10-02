words = []


def calculate_possibilities(word):
    print(f'Possibilities for "{word}" : {pow(len(word), 2)}')


def all_casings(input_string):
    if not input_string:
        yield ""
    else:
        first = input_string[:1]
        for sub_casing in all_casings(input_string[1:]):
            yield first.lower() + sub_casing
            yield first.upper() + sub_casing


def get_all_words():
    global words

    f = open('dict_origine.txt', 'r')
    temp = f.read()
    f.close()

    words = temp.split()
    print(f'{len(words)} word(s) detected !')


def generate_all_combinations():
    for word in words:
        calculate_possibilities(word)
        final_list = list(all_casings(word))

        f = open(f'{word}.txt', 'w+')
        for i in final_list:
            f.write(i + '\n')
        f.close()


def main():
    get_all_words()
    generate_all_combinations()

    print('\nDone :)  ')


if __name__ == "__main__":
    main()
