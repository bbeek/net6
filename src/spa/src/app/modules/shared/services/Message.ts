export class Message {
    public text: string;
    public date: Date;

    public constructor(message: string) {
        this.text = message;
        this.date = new Date();
    }
}
