package com.chichito.demoreactive.models;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.SequenceGenerator;
import jakarta.validation.constraints.NotBlank;

@Entity
public class Pepe {

    @Id
    @GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "pepe_seq")
    @SequenceGenerator(name = "pepe_seq", sequenceName = "pepe_seq", allocationSize = 1)
    private long id;

    @NotBlank(message = "Name is mandatory")
    private String name;

    @NotBlank(message = "Email is mandatory")
    private String email;

    public Pepe() {
    }

    public Pepe(String name, String email) {
        this.name = name;
        this.email = email;
    }

    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getEmail() {
        return this.email;
    }

    public void setemail(String email) {
        this.email = email;
    }

}