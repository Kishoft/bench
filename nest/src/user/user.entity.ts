import { Post } from './post.entity';
import { Entity, Column, PrimaryGeneratedColumn, OneToMany } from 'typeorm';

@Entity()
export class User {
  @PrimaryGeneratedColumn()
  id: number;

  @Column({ type: "varchar"})
  firstName: string;

  @Column({ type: "varchar"})
  lastName: string;

  @Column({ type: "varchar"})
  email: string;

  @Column({ default: true })
  isActive: boolean;

  @OneToMany(type => Post, post => post.id)
  posts : Post[];
}
