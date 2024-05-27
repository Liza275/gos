#include <iostream>

struct abstract_object {
    int Number_b;
    const char *type;
    const char *model;
    const char* cargo;
    int distans;

    abstract_object(int  _Number_b, const char* _type, const char* _model, const char* _cargo,int _distans) {
        Number_b = _Number_b;
        type = _type;
        model = _model;
        cargo = _cargo;
        distans = _distans;
    }
};

struct node {//узел списка 
    abstract_object* object;
    node* next;
    node* prev;

    node(abstract_object* value){//конструктор с помощью которого создается узел
        object = value;
        next = nullptr;
        prev = nullptr;
    }
};

struct list {
    node* head;
    node* tail;

    list() {
        head = nullptr;
        tail = nullptr;
    }

    void add(abstract_object* value) {
        node* new_node = new node(value);
        if (is_empty()) {
            tail = new_node;
            head = new_node;
        }
        else {
            node* prevNode = nullptr;//предыдущий узел
            node* currentNode = head;

            if (currentNode->object->Number_b > value->Number_b) {//если у текущего элемента Number_b больше, чем у добавляемого
                new_node->next = currentNode;//элемент который мы добавляем будет идти до текущего
                new_node->prev = prevNode;//предыдущий элемент у добавляемого null(выше присваеваем prevNode значение null)
                head = new_node;//добавляемый элемент становится head
                currentNode->prev = new_node;//у текущего элемента ссылка на предыдущий будет новым элементом
                return;
            }

            prevNode = currentNode;
            currentNode = currentNode->next;

            while (currentNode != nullptr) {
                if (currentNode->object->Number_b > value->Number_b) {
                    new_node->next = currentNode;//элемент который мы добавляем будет идти до текущего
                    new_node->prev = prevNode;//предыдущий элемент у добавляемого будет (текущий или null)
                    currentNode->prev = new_node;
                    prevNode->next = new_node;
                    return;
                }
                else {
                    prevNode = currentNode;
                    currentNode = currentNode->next;
                }
            }

            new_node->next = currentNode;
            new_node->prev = prevNode;
            tail = new_node;
            prevNode->next = new_node;
        }
    }

    void print_list() {
        if (is_empty()) {
            printf("List is empty\n");
            return;
        }

        node* currentNode = head;
        int i = 1;
        printf("List:\n");
        while (currentNode != nullptr)
        {
            printf("Element %d - %d %s %d\n",i,currentNode->object->integer, currentNode->object->string, currentNode->object->boolean);
            i++;
            currentNode = currentNode->next;
        }
    }

    bool is_empty() {
        return head == nullptr && tail == nullptr;
    }
};

int main()
{
    list myList = list();
    myList.print_list();
    abstract_object test1 = abstract_object(10, "test1", false);
    abstract_object test2 = abstract_object(15, "test2", true);
    abstract_object test3 = abstract_object(12, "test3", false);
    abstract_object test4 = abstract_object(19, "test4", false);
    abstract_object test5 = abstract_object(0, "test5", true);
    myList.add(&test1);
    myList.print_list();
    myList.add(&test2);
    myList.print_list();
    myList.add(&test3);
    myList.print_list();
    myList.add(&test4);
    myList.print_list();
    myList.add(&test4);
    myList.print_list();
    myList.add(&test5);
    myList.print_list();
    myList.add(&test1);
    myList.print_list();
    myList.add(&test2);
    myList.print_list();
    myList.add(&test3);
    myList.print_list();
    myList.add(&test4);
    myList.print_list();
    myList.add(&test4);
    myList.print_list();
    myList.add(&test5);
    myList.print_list();
}

// Запуск программы: CTRL+F5 или меню "Отладка" > "Запуск без отладки"
// Отладка программы: F5 или меню "Отладка" > "Запустить отладку"

// Советы по началу работы 
//   1. В окне обозревателя решений можно добавлять файлы и управлять ими.
//   2. В окне Team Explorer можно подключиться к системе управления версиями.
//   3. В окне "Выходные данные" можно просматривать выходные данные сборки и другие сообщения.
//   4. В окне "Список ошибок" можно просматривать ошибки.
//   5. Последовательно выберите пункты меню "Проект" > "Добавить новый элемент", чтобы создать файлы кода, или "Проект" > "Добавить существующий элемент", чтобы добавить в проект существующие файлы кода.
//   6. Чтобы снова открыть этот проект позже, выберите пункты меню "Файл" > "Открыть" > "Проект" и выберите SLN-файл.
